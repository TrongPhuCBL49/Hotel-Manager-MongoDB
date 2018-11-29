/*
    This file was automatically generated by Studio 3T.

    MongoDB Source Collection: `HotelManager.NhanVien`

    Warnings about type conversion issues are stored as comments above the
    corresponding INSERT statement of each document.
*/


SET NAMES 'utf8' COLLATE 'utf8_general_ci';

DROP TABLE IF EXISTS `NhanVien`;
CREATE TABLE `NhanVien` (
    `Cmnd` LONGTEXT,
    `DiaChi` LONGTEXT,
    `Email` LONGTEXT,
    `GioiTinh` LONGTEXT,
    `Id` LONGTEXT,
    `NgaySinh` DATETIME,
    `Sdt` LONGTEXT,
    `Ten` LONGTEXT,
    `_id` VARBINARY(12) NOT NULL,
    PRIMARY KEY (`_id`)
) CHARSET=utf8;

INSERT INTO `NhanVien` (`Cmnd`, `DiaChi`, `Email`, `GioiTinh`, `Id`, `NgaySinh`, `Sdt`, `Ten`, `_id`)
    VALUES
        ('251185733', '8 Âu Dương Lân', 'betra@gmail.com', 'Nữ', 'NV1', '1999-09-27 00:00:00.000000', '0973722822', 'Nguyễn Thị Thanh Trà', x'5BEA0A2FF3A066A50E16F9C8');
INSERT INTO `NhanVien` (`Cmnd`, `DiaChi`, `Email`, `GioiTinh`, `Id`, `NgaySinh`, `Sdt`, `Ten`, `_id`)
    VALUES
        ('251167733', '350/6 Bùi Hữu Nghĩa', 'trongphu@gmail.com', 'Nữ', 'NV2', '1998-10-22 00:00:00.000000', '0973712822', 'Nguyễn Trọng Phú', x'5BEA0A5FF3A066A50E16F9C9');
INSERT INTO `NhanVien` (`Cmnd`, `DiaChi`, `Email`, `GioiTinh`, `Id`, `NgaySinh`, `Sdt`, `Ten`, `_id`)
    VALUES
        ('261167733', '6 Hoàng Diệu 2', 'sonhavip5@gmail.com', 'Nữ', 'NV3', '1997-12-27 00:00:00.000000', '0973712812', 'Hồ Ngọc Sơn Hà', x'5BEA0A8FF3A066A50E16F9CA');