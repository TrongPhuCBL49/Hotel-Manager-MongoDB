using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        private string _id;
        private string _ten;
        private string _loaiPhong;
        private string _trangThai;

        public string Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string LoaiPhong { get => _loaiPhong; set => _loaiPhong = value; }
        public string TrangThai { get => _trangThai; set => _trangThai = value; }
    }
}
