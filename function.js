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
  	_id: "doiMatKhau",
	value: function(idNhanVien, password) 
	{
	  try
	  {
	  	db.Users.updateOne(
	  		{IdNhanVien: idNhanVien},
	  		{$set: {"Password": password}}
	  	);
	  	return 1;
	  }
	  catch (e){
	  	return 0;
	  }
	}
});

db.loadServerScripts()

