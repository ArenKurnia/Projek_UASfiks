-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 04, 2022 at 10:36 AM
-- Server version: 10.4.21-MariaDB
-- PHP Version: 8.0.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_uts`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_alumni`
--

CREATE TABLE `tb_alumni` (
  `NIM` varchar(767) NOT NULL,
  `Nama_alumni` text NOT NULL,
  `Tahun_angkatan` int(11) NOT NULL,
  `Jenis_kelamin` text NOT NULL,
  `Tempat_lahir` text NOT NULL,
  `Tanggal_lahir` datetime NOT NULL,
  `Pekerjaan` text NOT NULL,
  `Alamat` text NOT NULL,
  `Telp` text NOT NULL,
  `Foto` text NOT NULL,
  `RolesId` varchar(767) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_alumni`
--

INSERT INTO `tb_alumni` (`NIM`, `Nama_alumni`, `Tahun_angkatan`, `Jenis_kelamin`, `Tempat_lahir`, `Tanggal_lahir`, `Pekerjaan`, `Alamat`, `Telp`, `Foto`, `RolesId`) VALUES
('02031911057', 'Hanafi Abdullah', 2019, 'Laki-Laki', 'Boyolali', '2000-02-23 09:49:00', 'Dosen', 'Kp. Senang, Desa Andong', '085887866742', 'hanafi.jpeg', NULL),
('02042011002', 'Aren Kurnia', 2020, 'Perempuan', 'Subang', '2022-02-04 05:35:00', 'Mahasiswa', 'Kec. Patokbeusi', '085887866742', 'download.png', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `tb_event`
--

CREATE TABLE `tb_event` (
  `Id_event` varchar(767) NOT NULL,
  `Id_angkatan` varchar(767) DEFAULT NULL,
  `Nama_event` text NOT NULL,
  `Tanggal` datetime NOT NULL,
  `Tempat` text NOT NULL,
  `Waktu` text NOT NULL,
  `Batas_daftar` datetime NOT NULL,
  `Keterangan` text NOT NULL,
  `Status` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_event`
--

INSERT INTO `tb_event` (`Id_event`, `Id_angkatan`, `Nama_event`, `Tanggal`, `Tempat`, `Waktu`, `Batas_daftar`, `Keterangan`, `Status`) VALUES
('Event_01', '19', 'Reuni Dadakan ( Dadakan Pisan... Eleh Tahu Bulat Oge ! )', '2022-02-04 05:38:00', 'Kampus Tercinta PASIM', '19.00', '2022-02-03 03:39:00', 'Ayo Reuni Bosquuuuw', 'Mendatang'),
('Event_02', '19', 'Alhamdulillah Beres Oge Projekan Abi', '2022-02-04 03:51:00', 'ASBAR', '03.51', '2022-02-04 03:52:00', 'Alhamdulillah, Register, Login, Create, Read, Auth, Helper, Logout, Boostrap', 'Selesai');

-- --------------------------------------------------------

--
-- Table structure for table `tb_roles`
--

CREATE TABLE `tb_roles` (
  `Id` varchar(767) NOT NULL,
  `Username` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_roles`
--

INSERT INTO `tb_roles` (`Id`, `Username`) VALUES
('1', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `tb_tahun`
--

CREATE TABLE `tb_tahun` (
  `Id_angkatan` varchar(767) NOT NULL,
  `Tahun_angkatan` text NOT NULL,
  `Nama_angkatan` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_tahun`
--

INSERT INTO `tb_tahun` (`Id_angkatan`, `Tahun_angkatan`, `Nama_angkatan`) VALUES
('16', '2017', 'Mallware'),
('17', '2018', 'Firewall'),
('18', '2019', 'JARVIS'),
('19', '2020', 'Neophyte'),
('20', '2021', 'INTEGER');

-- --------------------------------------------------------

--
-- Table structure for table `tb_user`
--

CREATE TABLE `tb_user` (
  `Username` varchar(767) NOT NULL,
  `Password` text NOT NULL,
  `Nama_Lengkap` text NOT NULL,
  `Email` text NOT NULL,
  `RolesId` varchar(767) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tb_user`
--

INSERT INTO `tb_user` (`Username`, `Password`, `Nama_Lengkap`, `Email`, `RolesId`) VALUES
('aren', '06032001', 'Aren Kurnia', 'arenkurnia@gmail.com', '1'),
('hanafi', '23042000', 'Hanafi Abdullah', 'hanafiabdullah375@gmail.com', '1');

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20220203172712_Alumni', '5.0.13');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_alumni`
--
ALTER TABLE `tb_alumni`
  ADD PRIMARY KEY (`NIM`),
  ADD KEY `IX_Tb_Alumni_RolesId` (`RolesId`);

--
-- Indexes for table `tb_event`
--
ALTER TABLE `tb_event`
  ADD PRIMARY KEY (`Id_event`),
  ADD KEY `IX_Tb_Event_Id_angkatan` (`Id_angkatan`);

--
-- Indexes for table `tb_roles`
--
ALTER TABLE `tb_roles`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `tb_tahun`
--
ALTER TABLE `tb_tahun`
  ADD PRIMARY KEY (`Id_angkatan`);

--
-- Indexes for table `tb_user`
--
ALTER TABLE `tb_user`
  ADD PRIMARY KEY (`Username`),
  ADD KEY `IX_Tb_User_RolesId` (`RolesId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tb_alumni`
--
ALTER TABLE `tb_alumni`
  ADD CONSTRAINT `FK_Tb_Alumni_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`);

--
-- Constraints for table `tb_event`
--
ALTER TABLE `tb_event`
  ADD CONSTRAINT `FK_Tb_Event_Tb_Tahun_Id_angkatan` FOREIGN KEY (`Id_angkatan`) REFERENCES `tb_tahun` (`Id_angkatan`);

--
-- Constraints for table `tb_user`
--
ALTER TABLE `tb_user`
  ADD CONSTRAINT `FK_Tb_User_Tb_Roles_RolesId` FOREIGN KEY (`RolesId`) REFERENCES `tb_roles` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
