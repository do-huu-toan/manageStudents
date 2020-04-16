Tổng quát: 
Trong Tuần: 

- Trong tiết học:
	+ 5p đầu: Yêu cầu điểm danh
	+ Sau khi điểm danh xong cho nhập sĩ số lớp
	+ Cho phép nhập sĩ số lớp
- Kết thúc tiết học:
	+ Cộng số tiết cho giáo viên
- Ngoài tiết học:
	+ Thông báo ngoài tiết học



Chi tiết 1:
- Nếu lớp chưa có giáo viên và thời gian nằm trong tiết 1, tiết 2, tiết 3 thì:
	+ Yêu cầu nhập ID giáo viên:
- Nếu đã có giáo viên trong lớp: 
	+ Thì hiển thị sĩ số
	+ Cho phép thay đổi sĩ số
- Nếu hết giờ:
	+ Cộng cho giáo viên đấy giờ dậy
	+ Xóa trắng Node (giáo viên trong lớp)
	+ Xóa trắng sĩ số

PseudoCode:
- Cho thời gian request liên tục: time.update();
- Xác định xem thời gian hiện tại là tiết thứ mấy? Nếu là trong tiết học thì: 
	+ Xét tiếp xem có giáo viên chưa? Nếu chưa có thì chạy chạy hàm NhapID()
		+ String ID += getKey();
		+ Nếu ấn phím A thì kiểm tra xem giáo viên nào? nếu không đúng giáo viên nào thì not found, nếu trùng thì PushNode(teacherInClass)
	+ Nếu có giáo viên rồi thì in ra sĩ số hiện tại và Enable NhapSiSo()
		+ Nếu ấn B thì nhapSiSoEnable = true;
		+ Nếu nhapSiSoEnable = true thì siSo += getKey
		+ Đến khi ấn A (Enter) thì PushNode(present);
		+ Nếu nhapSiSoEnable = false thì in ra màn hình thông báo sĩ số hiện tại	
		+ Nếu ấn C (Cancel) đẩy ra màn hình yêu cầu nhập ID

