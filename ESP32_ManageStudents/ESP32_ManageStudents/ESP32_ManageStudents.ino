#include "quanLy.h"
#include<WiFi.h>
#include <IOXhop_FirebaseESP32.h> //Thư viện cho ESP32
#define FIREBASE_HOST "quanlygioday-ab237.firebaseio.com" //Máy chủ Firebase
#define FIREBASE_AUTH "1ntE2kAqSA5OuMEomXoaaCNLZcrPypz8qJbtOp4L" //mã secret
#define WIFI_SSID "wifi free" //Tên WiFi
#define WIFI_PASSWORD "toan123456" //Pass WiFi

#include<WiFiUdp.h>
#include<NTPClient.h>
WiFiUDP u;
NTPClient n(u, "2.asia.pool.ntp.org", 7 * 3600); //Lấy Time

//Thư viện LCD, KeyPad
#include <Wire.h>  // This library is already built in to the Arduino IDE
#include <LiquidCrystal_I2C.h> //This library you can add via Include Library > Manage Library > 
LiquidCrystal_I2C lcd(0x27, 16, 2);
#include <Keypad.h>
//RFID:
#include <SPI.h>
#include <MFRC522.h> // thu vien "RFID".
#define SS_PIN 2
#define RST_PIN 4
MFRC522 mfrc522(SS_PIN, RST_PIN);
unsigned long uidDec, uidDecTemp; // hien thi so UID dang thap phan

//-----------
String ID = "";

char keys[4][4] = {
  {'1', '2', '3', 'A'},
  {'4', '5', '6', 'B'},
  {'7', '8', '9', 'C'},
  {'*', '0', '#', 'D'}
};
/*
  byte colPin[4] = {15, 2, 0, 4};
  byte rowPin[4] = {16, 17, 5, 18};
*/
byte colPin[4] = {13, 32, 33, 25};
byte rowPin[4] = {26, 27, 14, 12};
Keypad keypad = Keypad(makeKeymap(keys), rowPin, colPin, 4, 4);

String giaoVien = "";
String SiSo = "";
bool isEnter = false;
bool enableKey = true;

int trangThaiLCD = 1;// Dừng in
int Mode = 1;
bool danhChuong = false;
unsigned long timer1; //Lưu thời gian đánh chuông
int chuong = 3;
bool congTiet = false;
/*
   Mode = 1: Chưa có giáo viên, nhập ID
   Mode = 2: Có giáo viên rồi, Yêu cầu nhập Sĩ số
   Mode = 3: Có giáo viên rồi, nhập sĩ số rồi, Teaching
*/
//-----------------------Khởi tạo tiết-------------------------------------------------
Time S1(0, 0);
Time E1(0, 0);

Time S2(0, 0);
Time E2(0, 0);

Time S3(0, 0);
Time E3(0, 0);

Time S4(0, 0);
Time E4(0, 0);

Time S5(0, 0);
Time E5(0, 0);
//----------------------Check tiết học--------------------------------------------------
int checkTietHoc(Time t)
{
  Time S0(7, 0);
  Time E0(7, 15);

  int tiet = -1;
  if (checkInTime(t, S0, E0) == true) tiet = 0;
  if (checkInTime(t, S1, E1) == true) tiet = 1;
  if (checkInTime(t, S2, E2) == true) tiet = 2;
  if (checkInTime(t, S3, E3) == true) tiet = 3;
  if (checkInTime(t, S4, E4) == true) tiet = 4;
  if (checkInTime(t, S5, E5) == true) tiet = 5;

  return tiet;
}
bool cmpTime(Time time1, Time time2)
{
  bool result = false;
  if (time1.Hours == time2.Hours && time1.Minutes == time2.Minutes)result = true;
  return result;
}
//-----------------------END------------------------------------------------------------
void setup() {
  pinMode(chuong, OUTPUT);
  Serial.begin(115200);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD); //Kết nối WiFi
  Serial.print("connecting");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println();
  Serial.print("connected: ");
  Serial.println(WiFi.localIP()); //IP WiFi
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
  n.begin();
  lcd.init();   // initializing the LCD
  lcd.backlight(); // Enable or Turn On the backlight
  lcd.println("Load Database");
  //RFID
  SPI.begin();
  mfrc522.PCD_Init();
  //---------------------------LOAD TIME-------------------------------------
  S1.Hours = Firebase.getInt("/quanlygioday-ab237/Time/1/Start/Hours");
  S1.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/1/Start/Minutes");

  S2.Hours = Firebase.getInt("/quanlygioday-ab237/Time/2/Start/Hours");
  S2.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/2/Start/Minutes");

  S3.Hours = Firebase.getInt("/quanlygioday-ab237/Time/3/Start/Hours");
  S3.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/3/Start/Minutes");

  S4.Hours = Firebase.getInt("/quanlygioday-ab237/Time/4/Start/Hours");
  S4.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/4/Start/Minutes");

  S5.Hours = Firebase.getInt("/quanlygioday-ab237/Time/5/Start/Hours");
  S5.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/5/Start/Minutes");
  //Het Tiet:
  E1.Hours = Firebase.getInt("/quanlygioday-ab237/Time/1/End/Hours");
  E1.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/1/End/Minutes");

  E2.Hours = Firebase.getInt("/quanlygioday-ab237/Time/2/End/Hours");
  E2.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/2/End/Minutes");

  E3.Hours = Firebase.getInt("/quanlygioday-ab237/Time/3/End/Hours");
  E3.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/3/End/Minutes");

  E4.Hours = Firebase.getInt("/quanlygioday-ab237/Time/4/End/Hours");
  E4.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/4/End/Minutes");

  E5.Hours = Firebase.getInt("/quanlygioday-ab237/Time/5/End/Hours");
  E5.Minutes = Firebase.getInt("/quanlygioday-ab237/Time/5/End/Minutes");

  //----------------------------END------------------------------------------
  giaoVien = Firebase.getString("/quanlygioday-ab237/TKB/10A/teacherOnClass");
  if (giaoVien != "")
  {
    Mode = 3;
    int n = Firebase.getInt("/quanlygioday-ab237/TKB/10A/present");
    SiSo = String(n);
    trangThaiLCD = 5;
  }
}

void loop()
{
  n.update();
  Time now(n.getHours(), n.getMinutes());
  int tietNow = checkTietHoc(now);
  int Day = n.getDay() + 1;
  //Bắt sự kiện Enter cho mỗi Mode

  if (tietNow >= 1 && tietNow <= 5) //Nếu mà thời gian nằm trong tiết 1-5 và không có gv trong lớp
  {
    if (Mode == 0)
    {
      Mode = 1;
      trangThaiLCD = 1;
    }
    if (cmpTime(now, S1) || cmpTime(now, S2) || cmpTime(now, S3) || cmpTime(now, S4) || cmpTime(now, S5))
    {
      if (congTiet == true)
      {
        congTiet = false;
      }
    }
    if (cmpTime(now, E1) || cmpTime(now, E2) || cmpTime(now, E3) || cmpTime(now, E4) || cmpTime(now, E5))
    {
      if (congTiet == false)
      {
        int counter = Firebase.getInt("/quanlygioday-ab237/listTeacher/Counter/count");
        for (int i = 1; i <= counter; i++)
        {
          String pathCheck = String("/quanlygioday-ab237/listTeacher/") + String(i);
          String giaoVienCheck = Firebase.getString(String(pathCheck) + String("/NameInTKB"));
          if (giaoVienCheck == giaoVien)
          {
            int soTietHienTai = Firebase.getInt(String(pathCheck) + String("/demGioDay"));
            Firebase.setInt(String(pathCheck) + String("/demGioDay"), ++soTietHienTai);
            Firebase.setInt("/quanlygioday-ab237/TKB/10A/present", 0);
            Firebase.setString("/quanlygioday-ab237/TKB/10A/teacherOnClass", String(""));
            congTiet = true;
            break;
          }
        }
      }

      if (danhChuong == false)
      {
        danhChuong = true;
        timer1 = millis();
      }
    }
    if (isEnter == true && Mode == 1)
    {

      //enableKey = false;
      String pathGiaoVien = String("/quanlygioday-ab237/listTeacher/") + String(ID) + String("/NameInTKB");
      String giaoVienNow = Firebase.getString(pathGiaoVien);
      Serial.println(giaoVienNow);
      if (giaoVienNow != "") //Nếu tồn tại ID
      {
        String path1 = String("/quanlygioday-ab237/TKB/10A/Thứ ") + String(Day) + String("/Tiết ") + String(tietNow) + String("/Teacher");//Đường dẫn tới thứ và tiết
        String giaoVienDung = Firebase.getString(path1);
        Serial.println(giaoVienDung);
        if (giaoVienNow == giaoVienDung)
        {
          Firebase.setString("/quanlygioday-ab237/TKB/10A/teacherOnClass", giaoVienNow);
          if (Firebase.failed())return;
          Mode = 2;
          trangThaiLCD = 4;
          giaoVien = giaoVienNow;
        }
        else
        {
          trangThaiLCD = 3;
          enableKey = true;
        }
      }
      else
      {
        trangThaiLCD = 2;
        enableKey = true;
      }
      isEnter = false;
      ID = "";
    }
    if (Mode == 2 && isEnter == true)
    {
      int numberStudents = atoi(SiSo.c_str());
      Firebase.setInt("/quanlygioday-ab237/TKB/10A/present", numberStudents);
      if (Firebase.failed())return;
      trangThaiLCD = 5;
      isEnter = false;
      Mode = 3;
    }
  }
  else
  {
    enableKey = false;
    trangThaiLCD = 7;
    Mode = 0;
  }
  if (enableKey == true)
  {
    char pressed = keypad.getKey();
    if (pressed)
    {
      Serial.println(pressed);
      if (enableKey == true && pressed != 'D' && pressed != 'C'  && Mode == 1)
      {
        ID += pressed;
        lcd.print(pressed);
      }
      if (enableKey == true && pressed != 'D' && pressed != 'C' && Mode == 2)
      {
        SiSo += pressed;
        lcd.print(pressed);
      }
      if (pressed == 'D')
      {
        lcd.print(pressed);
        isEnter = true;
        trangThaiLCD = 6;
      }
      if (pressed == 'A')
      {
        if (Mode == 1)
        {
          trangThaiLCD = 1;
          ID = "";
        }
        if (Mode == 2)
        {
          trangThaiLCD = 4;
          SiSo = "";
        }
      }
      if (pressed == 'C') //Back
      {
        if (Mode == 3)
        {
          Mode = 2;
          Serial.println("Mode = 2");
          trangThaiLCD = 4;
        }
        else if (Mode == 2) //Không được if
        {
          Mode = 1;
          Serial.println("Mode = 1");
          trangThaiLCD = 1;
        }
      }
    }
  }

  //In LCD:
  if (trangThaiLCD == 1)
  {
    lcd.clear();
    lcd.println("Nhap ID: ");
    lcd.setCursor(0, 1);
    trangThaiLCD = 0;
  }
  if (trangThaiLCD == 2)
  {
    lcd.clear();
    lcd.println("Sai giao vien");
    delay(1000);
    ID = "";
    trangThaiLCD = 1;
  }
  if (trangThaiLCD == 3)
  {
    lcd.clear();
    lcd.println("Sai gio");
    delay(1000);
    ID = "";
    trangThaiLCD = 1;
  }
  if (trangThaiLCD == 4)
  {
    lcd.clear();
    lcd.println("Nhap si so: ");
    lcd.setCursor(0, 1);
    trangThaiLCD = 0;

  }
  if (trangThaiLCD == 5)
  {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.println("Teaching...");
    //lcd.println(String("Teacher:") + String(giaoVien));
    lcd.setCursor(0, 1);
    lcd.print("Students:");
    lcd.print(SiSo);
    trangThaiLCD = 0;
    SiSo = "";
  }
  if (trangThaiLCD == 6)
  {
    lcd.clear();
    lcd.println("Loading...");
    trangThaiLCD = 0;
  }
  if (trangThaiLCD == 7)
  {
    lcd.clear();
    lcd.println("Ngoai Gio Hoc");
    trangThaiLCD = 0;
  }
  if (danhChuong == true)
  {
    if (millis() - timer1 <= 5000)
    {
      digitalWrite(chuong, HIGH);
      Serial.println(millis() - timer1);
    }
    else
    {
      digitalWrite(chuong, LOW);
    }
  }
}

void docThe()
{
  if ( ! mfrc522.PICC_IsNewCardPresent()) {
    return;
  }

  // Doc the
  if ( ! mfrc522.PICC_ReadCardSerial()) {
    return;
  }

  uidDec = 0;
  Serial.println("MMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMM");
  Serial.println("================================================");

  // Hien thi so UID cua the
  Serial.println("Card UID: ");
  for (byte i = 0; i < mfrc522.uid.size; i++) {
    uidDecTemp = mfrc522.uid.uidByte[i];
    uidDec = uidDec * 256 + uidDecTemp;
  }
  Serial.print("            [");
  Serial.print(uidDec);
  Serial.println("]");
  Serial.println("================================================");
  mfrc522.PICC_HaltA();

}
