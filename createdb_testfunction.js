db.ChucDanh.insert({id: 1, TenChucDanh: "Giám đốc"})
db.ChucDanh.insert({id: 2, TenChucDanh: "Quản lý"})
db.ChucDanh.insert({"id": int32(4), "TenChucDanh": "Lễ t"})

db.Users.remove({id: "NV2"})

db.Users.find()

db.Users.insert(
	{
	  IdNhanVien: "NV2", 
	  Password: "456", 
	  ChucDanh: "Quản lý"
	}
)

db.LoaiPhong.insert(
	{
	  Id : NumberInt(2),
	  Ten : "Phòng đôi thường", 
	  Gia : NumberInt(800000), 
	  TienPhuthu : NumberInt(45000), 
	  SoGiuong : NumberInt(2)
	}
)

db.LoaiPhong.find()

var idPhong = db.LoaiPhong.findOne({Id: 2})

db.Phong.insert(
	{
	  Id: "DT202",
	  Ten: "202",
	  LoaiPhong: ObjectId("5be9f4a2f3a066a50e16f9ba"),
	  TrangThai: "Chưa đặt"
	}
)

db.DichVu.find()
db.LoaiPhong.findOne(Id: 1)._id

db.DichVu.insert(
	{
	  Id: NumberInt(3),
	  Ten: "Bò húc",
	  Gia: NumberInt(15000)
	}
)
db.DichVu.find()

db.NhanVien.insert(
	{
	  Id: "NV3",
	  Ten: "Hồ Ngọc Sơn Hà",
	  NgaySinh: ISODate("1998-11-27"),
	  GioiTinh: "Nam",
	  DiaChi: "6 Hoàng Diệu 2",
	  Sdt: "0973712812",
	  Cmnd: "261167733",
	  Email: "sonhavip4@gmail.com"
	}
)

db.NhanVien.find()
db.NhanVien.remove({Id: {$exists: true}})

db.KhachHang.insert(
	{
	  Id: "KH2",
	  Ten: "Nguyễn Ngọc Vũ Giao",
	  NgaySinh: ISODate("1998-01-10"),
	  GioiTinh: "Nam",
	  DiaChi: "120 Dương Bá Trạc",
	  Sdt: "0872912812",
	  Cmnd: "291867733",
	  QuocTich: "Việt Nam"
	}
)

function insertDichVu(Id, Ten, Gia)
{
	db.DichVu.insert(
		{
			Id: NumberInt(Id),
			Ten: Ten,
			Gia: NumberInt(Gia)
		}	
	);
}

function findLoaiPhong(tenPhong)
{
  var Phong = db.Phong.findOne({Ten: tenPhong});
  var TenLoaiPhong = db.LoaiPhong.find(
								         { _id: Phong.LoaiPhong},
  									  );
  return TenLoaiPhong.Ten;
}

db.eval(function(tenPhong)
{
  var phong = db.Phong.findOne({Ten: tenPhong});
  var idLoaiPhong = phong.LoaiPhong;
  var tenLoaiPhong = db.LoaiPhong.findOne({ _id: idLoaiPhong});
  return tenLoaiPhong.Ten;
}, "102")

db.system.js.save()

db.system.js.save({
    _id: "loaiPhong",
    value: function(tenPhong)
{
  var phong = db.Phong.findOne({Ten: tenPhong});
  var idLoaiPhong = phong.LoaiPhong;
  var tenLoaiPhong = db.LoaiPhong.findOne({ _id: idLoaiPhong});
  return tenLoaiPhong.Ten;
}
})
loaiPhong("101")
db.eval("loaiPhong('101')")
db.eval(function()
{
  var Phong = db.Phong.findOne({Ten: "101"});
  var id = Phong.LoaiPhong;
  var TenPhong = db.LoaiPhong.findOne({_id: id});
  return TenPhong.Ten;
}
)

db.LoaiPhong.find()

findLoaiPhong("101")
insertDichVu(4, "Giặt ủi", 20000)

db.DichVu.find()

db.eval()

db.Users.find({$and: [{"IdNhanVien": "NV1"}, {"Password": "123"}]}).count()