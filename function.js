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

db.loadServerScripts()

db.LoaiPhong.find()
db.Users.find()
db.runCommand({ eval: "idLoaiPhong('Phòng đơn thường')"})
idLoaiPhong('Phòng đơn thường')
xoaLoaiPhong("3")

var a = '5be9f4a2f3a066a50e16f9ba';
suaDichVu("2", "Sting", ObjectId(a), "Chưa đặt")
print(a);

xoaNhanVien("NV4")

db.NhanVien.find()

db.NhanVien.update(
	{GioiTinh: "Nam"},
	{$set: {GioiTinh: "Nữ"}},
	{
	  upsert: false,
	  multi: true
	}
)

