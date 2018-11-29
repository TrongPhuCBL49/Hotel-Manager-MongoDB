db.system.js.save({
    _id: "loaiPhong",
    value: function(tenPhong)
	{
  		var phong = db.Phong.findOne({Ten: tenPhong});
  		var idLoaiPhong = phong.LoaiPhong;
  		var tenLoaiPhong = db.LoaiPhong.findOne({ _id: idLoaiPhong});
  		return tenLoaiPhong.Ten;
	}
});

db.system.js.save({
    _id: "idLoaiPhong",
    value: function(tenLoaiPhong)
	{
  		var loaiPhong = db.LoaiPhong.findOne({Ten: tenLoaiPhong});
  		var result = loaiPhong._id;
  		return result.toString();
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
    	try 
    	{
      		db.Users.updateOne(
      			{ IdNhanVien:idNhanVien }, 
      			{ $set:{Password:password}}
      		);
      		return 1;
    	} 
    	catch (e){
      	return 0;
      	}
	}
});

db.system.js.save({
  	_id: "themChucDanh",
	value: function(id, tenChucDanh) 
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
	value: function(id, tenDichVu, gia) 
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
  	_id: "themThuePhongTG",
	value: function(id, idPhong, idNhanVien, idKhachHang, checkIn, checkOut, tienDatCoc, trangThai) 
	{
	  try
	  {					
	  	db.BangThuePhong.insertOne(
	  		{Id: id,
	  		 IdPhong: idPhong,
	  		 IdNhanVien: idNhanVien,
	  		 IdKhachHang: idKhachHang,
	  		 CheckIn: checkIn,
	  		 CheckOut: checkOut,
	  		 TienDatCoc: tienDatCoc,
	  		 TrangThai: trangThai}
	  	);
	  	db.Phong.update(
	  		{Id: idPhong},
	  		{$set: {TrangThai: "Đã đặt"}},
	  		{
	  		  upsert: false,
	  		  multi: false
	  		}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

/*db.system.js.save({
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
});*/

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

/*db.system.js.save({
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
});*/

/*db.system.js.save({
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
});*/

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
	value: function(id, tenChucDanh) 
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
	value: function(id, tenDichVu, gia) 
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
	value: function(id, tenDichVu, gia) 
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
	    var idLoaiPhong = loaiPhong;
	  	db.Phong.updateOne(
	  		{Id: id},
	  		{$set: {Ten:tenPhong, LoaiPhong:idLoaiPhong, TrangThai:trangThai}}
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
	value: function(id, password, chucDanh) 
	{
	  try
	  {					
	  	db.Users.updateOne(
	  		{IdNhanVien: id},
	  		{$set: {Password:password, ChucDanh:chucDanh}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

/*db.system.js.save({
  	_id: "themRole",
	value: function(tenRole) 
	{
	  try
	  {					
	    use admin;
		db.createRole()
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

    "updateRole" : "GiamDoc", 
    "privileges" : [
        {
            "resource" : {
                "anyResource" : true
            }, 
            "actions" : [
                "anyAction"
            ]
        }
    ], 
    "roles" : [

    ]*/








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
  	_id: "xoaLoaiPhong",
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
  	_id: "xoaNhanVien",
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








/*db.system.js.save({
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
});*/


db.system.js.save({
  	_id: "xoaChucDanh",
	value: function(id) 
	{
	  try
	  {		
	    var object_Ten=db.ChucDanh.findOne({Id:id}).TenChucDanh;
	    db.Users.update(
	  		{ChucDanh:object_Ten},
	  		{$set:{ChucDanh:"Nhân Viên"}},
	  		{multi:true}
	  	);
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

db.loadServerScripts();

/*db.Phong.update(
	{TrangThai: "Đã đặt"},
	{$set: {TrangThai: "Chưa đặt"}},
	{
  		multi: true
	}
)
db.Phong.find()
db.BangThuePhong.find()*/

db.Users.find()

use HotelManagerPhu

db.createCollection("Test")