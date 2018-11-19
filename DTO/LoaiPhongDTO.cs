using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoaiPhongDTO
    {
        private string _id;
        private string _ten;
        private string _gia;
        private string _tienPhuThu;
        private string _soGiuong;

        public string Id { get => _id; set => _id = value; }
        public string Ten { get => _ten; set => _ten = value; }
        public string Gia { get => _gia; set => _gia = value; }
        public string TienPhuThu { get => _tienPhuThu; set => _tienPhuThu = value; }
        public string SoGiuong { get => _soGiuong; set => _soGiuong = value; }
    }
}
