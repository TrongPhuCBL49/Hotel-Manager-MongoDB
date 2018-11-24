db.system.js.save({
    _id: "loaiPhong",
    value: function(tenPhong)
	{
  		var phong = db.Phong.findOne({Ten: tenPhong});
  		var idLoaiPhong = phong.LoaiPhong;
  		var tenLoaiPhong = db.LoaiPhong.findOne({ _id: idLoaiPhong});
  		return tenLoaiPhong;
	}
});

db.system.js.save({
	_id: "kiemTraUser",
	value: function(idNhanVien, password) 
	{
	  var kq = db.Users.findOne({$and: [{IdNhanVien: idNhanVien}, {Password: password}]});
	  if(kq == null) return 0;
	  	else return 1;
	}
});

db.system.js.save({
	_id: "doiMatKhau",
	value: function(idNhanVien, password) 
	{
	  var kq = db.Users.findOne({$and: [{IdNhanVien: idNhanVien}, {Password: password}]});
	}
});

db.system.js.save({
  	_id: "themChucDanh",
	value: function(tenChucDanh, id) 
	{
	  try
	  {
	  	db.ChucDanh.insertOne(
	  		{TenChucDanh: tenChucDanh,
	  		Id:id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "themDichVu",
	value: function(tenDichVu, gia, id) 
	{
	  try
	  {
	  	db.DichVu.insertOne(
	  		{Ten: tenDichVu,
	  		 Gia: gia,
	  		 Id:id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "themKhachHang",
	value: function(id, tenKhachHang, ngaySinh, gioiTinh, sdt, cmnd, quocTich, email) 
	{
	  try
	  {					
	  	db.KhachHang.insertOne(
	  		{Id: id,
	  		 Ten: tenKhachHang,
	  		 NgaySinh: ngaySinh,
	  		 GioiTinh: gioiTinh,
	  		 Sdt: sdt,
	  		 Cmnd: cmnd,
	  		 QuocTich: quocTich,
	  		 Email: email}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "themLoaiPhong",
	value: function(id, tenLoaiPhong, gia, soGiuong, tienPhuThu) 
	{
	  try
	  {					
	  	db.LoaiPhong.insertOne(
	  		{Id: id,
	  		 Ten: tenLoaiPhong,
	  		 Gia: gia,
	  		 SoGiuong: soGiuong,
	  		 TienPhuThu: tienPhuThu}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "themNhanVien",
	value: function(id, tenNhanVien, ngaySinh, gioiTinh, diaChi, sdt, cmnd, email) 
	{
	  try
	  {					
	  	db.NhanVien.insertOne(
	  		{Id: id,
	  		 Ten: tenNhanVien,
	  		 NgaySinh: ngaySinh,
	  		 GioiTinh: gioiTinh,
	  		 DiaChi: diaChi,
	  		 Sdt: sdt,
	  		 Cmnd: cmnd,
	  		 Email: email}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "themPhong",
	value: function(id, tenPhong, loaiPhong, trangThai) 
	{
	  try
	  {					
	  	db.Phong.insertOne(
	  		{Id: id,
	  		 Ten: tenPhong,
	  		 LoaiPhong: loaiPhong,
	  		 TrangThai: trangThai}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "themUser",
	value: function(id, passWord, chucDanh) 
	{
	  try
	  {					
	  	db.Users.insertOne(
	  		{IdNhanVien: id,
	  		 Password: passWord,
	  		 ChucDanh: chucDanh}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaChucDanh",
	value: function(id) 
	{
	  try
	  {					
	  	db.ChucDanh.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaDichVu",
	value: function(id) 
	{
	  try
	  {					
	  	db.DichVu.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaKhachHang",
	value: function(id) 
	{
	  try
	  {					
	  	db.KhachHang.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaLoaiPhong",
	value: function(id) 
	{
	  try
	  {					
	  	db.LoaiPhong.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaNhanVien",
	value: function(id) 
	{
	  try
	  {					
	  	db.NhanVien.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaPhong",
	value: function(id) 
	{
	  try
	  {					
	  	db.Phong.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaUser",
	value: function(id) 
	{
	  try
	  {					
	  	db.Users.remove(
	  		{IdNhanVien: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaChucDanh",
	value: function(tenChucDanh, id) 
	{
	  try
	  {					
	  	db.ChucDanh.updateOne(
	  		{Id: id},
	  		{$set: {TenChucDanh:tenChucDanh}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaDichVu",
	value: function(tenDichVu, gia, id) 
	{
	  try
	  {					
	  	db.DichVu.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenDichVu,Gia:gia}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaDichVu",
	value: function(tenDichVu, gia, id) 
	{
	  try
	  {					
	  	db.DichVu.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenDichVu,Gia:gia}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaKhachHang",
	value: function(id, tenKhachHang, ngaySinh, gioiTinh, sdt, cmnd, quocTich, email) 
	{
	  try
	  {					
	  	db.KhachHang.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenKhachHang, NgaySinh:ngaySinh, GioiTinh:gioiTinh, Sdt:sdt,Cmnd:cmnd, QuocTich:quocTich, Email:email}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaLoaiPhong",
	value: function(id, tenLoaiPhong, gia, soGiuong, tienPhuThu) 
	{
	  try
	  {					
	  	db.LoaiPhong.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenLoaiPhong, Gia:gia, SoGiuong:soGiuong, TienPhuThu:tienPhuThu}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaNhanVien",
	value: function(id, tenNhanVien, ngaySinh, gioiTinh, diaChi, sdt, cmnd, email) 
	{
	  try
	  {					
	  	db.NhanVien.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenNhanVien, NgaySinh:ngaySinh, GioiTinh:gioiTinh, DiaChi:diaChi,Sdt:sdt, Cmnd:cmnd, Email:email}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaPhong",
	value: function(id, tenPhong, loaiPhong, trangThai) 
	{
	  try
	  {					
	  	db.Phong.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenPhong, LoaiPhong:loaiPhong, TrangThai:trangThai}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "suaUser",
	value: function(id, passWord, chucDanh) 
	{
	  try
	  {					
	  	db.Users.updateOne(
	  		{IdNhanVien: id},
	  		{$set: {Password:passWord, ChucDanh:chucDanh}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaPhongByLoaiPhong",
	value: function(object_Id) 
	{
	  try
	  {					
	  	db.Phong.remove(
	  		{LoaiPhong: object_Id},
	  		{justOne:false}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.system.js.save({
  	_id: "xoaLoaiPhongAsTrigger",
	value: function(id) 
	{
	  try
	  {		
	    var object_Id=db.LoaiPhong.findOne({Id:id})._id;
	    xoaPhongByLoaiPhong(object_Id);
	  	db.LoaiPhong.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});


db.system.js.save({
  	_id: "xoaNhanVienAsConstaint",
	value: function(id) 
	{
	  try
	  {		
	  	db.Users.remove(
	  		{IdNhanVien: id},
	  		{justOne:false}
	  	);
	  	db.NhanVien.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});








db.system.js.save({
  	_id: "setDefaultAsNhanVien",
	value: function(chucDanh) 
	{
	  try
	  {					
	  	db.Users.update(
	  		{ChucDanh:chucDanh},
	  		{$set:{ChucDanh:"Nhân Viên"}},
	  		{multi:true}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});


db.system.js.save({
  	_id: "xoaChucDanhSetDefault",
	value: function(id) 
	{
	  try
	  {		
	    var object_Ten=db.ChucDanh.findOne({Id:id}).TenChucDanh;
	    setDefaultAsNhanVien(object_Ten);
	  	db.ChucDanh.remove(
	  		{Id: id}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});
db.loadServerScripts()



xoaLoaiPhongAsTrigger("1");
db.DichVu.find()
suaDichVu("Chanh Đá","5500","6")
themChucDanh("Bảo Vệ","4");
themDichVu("Nước Chanh","5000","6");
themKhachHang("KH3","Nguyễn Trọng Phú",ISODate("1998-05-22"),"Nam","0873712812","291167736","Việt Nam","ntp@gmail.com")
themLoaiPhong("4","Phòng Đôi Vip","100000","2","60000")
themNhanVien("NV1","Nguyễn Thành Đồng",ISODate("1998-11-27T00:00:00.000+0000"),"Nam","Suối Tiên","0973712812","261167756","dattran@gmail.com")
xoaChucDanh("4")
	