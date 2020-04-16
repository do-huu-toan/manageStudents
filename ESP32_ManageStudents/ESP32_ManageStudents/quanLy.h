#ifndef _QUAN_LY_H_
#define _QUAN_LY_H_

//Thư viện: 


 //Thư viện thời gian thực'
//Kết thúc thư viện
struct Time
{
  int Hours, Minutes;
  Time(int _Hours, int _Minutes);
  //int checkTietHoc();
  
};

bool checkInTime(Time check, Time Start, Time End)
{
    if(Start.Hours < End.Hours)
    {
        if(check.Hours == Start.Hours)
        {
            if(check.Minutes >= Start.Minutes) return true;
            else return false;
        }
        else if(check.Hours == End.Hours)
        {
            if(check.Minutes <= Start.Minutes) return true;
            else return false;
        }
        else if(check.Hours > Start.Hours && check.Hours < End.Hours) return true;
        else return false;

    }
    if(Start.Hours == End.Hours)
    {
        if(check.Hours == Start.Hours)
        {
            if(check.Minutes >= Start.Minutes && check.Minutes <= End.Minutes)return true;
            else return false;
        }
        else return false;
    }
    if(Start.Hours > End.Hours)return false;

}

//Function
Time::Time(int _Hours, int _Minutes)
{
  Hours = _Hours;
  Minutes = _Minutes;
}


#endif
