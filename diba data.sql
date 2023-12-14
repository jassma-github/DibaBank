-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: diba
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.25-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `addressbook`
--

DROP TABLE IF EXISTS `addressbook`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `addressbook` (
  `id_pengguna` varchar(16) NOT NULL,
  `no_rekening` varchar(11) NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `tgl_input` datetime NOT NULL,
  KEY `fk_pengguna_tabungan_tabungan1_idx` (`no_rekening`),
  KEY `fk_pengguna_tabungan_pengguna1_idx` (`id_pengguna`),
  CONSTRAINT `fk_pengguna_tabungan_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_pengguna_tabungan_tabungan1` FOREIGN KEY (`no_rekening`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `addressbook`
--

LOCK TABLES `addressbook` WRITE;
/*!40000 ALTER TABLE `addressbook` DISABLE KEYS */;
INSERT INTO `addressbook` VALUES ('2101012002020001','98099876781','','2023-01-16 15:38:03');
/*!40000 ALTER TABLE `addressbook` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bunga`
--

DROP TABLE IF EXISTS `bunga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bunga` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `persentase` double NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bunga`
--

LOCK TABLES `bunga` WRITE;
/*!40000 ALTER TABLE `bunga` DISABLE KEYS */;
INSERT INTO `bunga` VALUES (1,'Bunga Rekening',3.6),(2,'Pajak Bunga Rekening',10),(3,'Bunga Deposito 1 Bulan',3),(4,'Bunga Deposito 3 Bulan',5),(5,'Bunga Deposito 6 Bulan',6),(6,'Bunga Deposito 12 Bulan',8),(7,'Penalty Deposito',5);
/*!40000 ALTER TABLE `bunga` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bunga_tabungan`
--

DROP TABLE IF EXISTS `bunga_tabungan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bunga_tabungan` (
  `tabungan_no_rekening` varchar(11) NOT NULL,
  `tanggal` datetime NOT NULL,
  `bunga_id` int(11) NOT NULL,
  `pajak_id` int(11) DEFAULT NULL,
  `bungaNominal` double DEFAULT NULL,
  `pajakNominal` double DEFAULT NULL,
  PRIMARY KEY (`tanggal`),
  KEY `fk_bunga_tabungan_tabungan1_idx` (`tabungan_no_rekening`),
  KEY `fk_bunga_tabungan_bunga1_idx` (`bunga_id`),
  KEY `fk_bunga_tabungan_bunga2_idx` (`pajak_id`),
  CONSTRAINT `fk_bunga_tabungan_bunga1` FOREIGN KEY (`bunga_id`) REFERENCES `bunga` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bunga_tabungan_bunga2` FOREIGN KEY (`pajak_id`) REFERENCES `bunga` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_bunga_tabungan_tabungan1` FOREIGN KEY (`tabungan_no_rekening`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bunga_tabungan`
--

LOCK TABLES `bunga_tabungan` WRITE;
/*!40000 ALTER TABLE `bunga_tabungan` DISABLE KEYS */;
INSERT INTO `bunga_tabungan` VALUES ('98099876781','2023-01-15 15:31:34',1,2,597,0);
/*!40000 ALTER TABLE `bunga_tabungan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `deposito`
--

DROP TABLE IF EXISTS `deposito`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `deposito` (
  `id_deposito` varchar(45) NOT NULL,
  `no_rekening` varchar(11) NOT NULL,
  `jatuh_tempo` datetime NOT NULL,
  `nominal` double NOT NULL,
  `bunga` double NOT NULL,
  `pajakNominal` double DEFAULT NULL,
  `penaltyNominal` double DEFAULT NULL,
  `status` enum('aktif','nonaktif','proses cair','cair') NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `verifikator_buka` int(11) DEFAULT NULL,
  `verifikator_cair` int(11) DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `bungaDeposito_id` int(11) NOT NULL,
  `pajakBunga_id` int(11) DEFAULT NULL,
  `penalty_id` int(11) DEFAULT NULL,
  `bulan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_deposito`),
  KEY `fk_deposito_employee1_idx` (`verifikator_buka`),
  KEY `fk_deposito_employee2_idx` (`verifikator_cair`),
  KEY `fk_deposito_bunga1_idx` (`bungaDeposito_id`),
  KEY `fk_deposito_bunga3_idx` (`penalty_id`),
  KEY `fk_deposito_bunga2_idx` (`pajakBunga_id`),
  KEY `fk_deposito_tabungan1_idx` (`no_rekening`),
  CONSTRAINT `fk_deposito_bunga1` FOREIGN KEY (`bungaDeposito_id`) REFERENCES `bunga` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_bunga2` FOREIGN KEY (`pajakBunga_id`) REFERENCES `bunga` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_bunga3` FOREIGN KEY (`penalty_id`) REFERENCES `bunga` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_employee1` FOREIGN KEY (`verifikator_buka`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_employee2` FOREIGN KEY (`verifikator_cair`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_deposito_tabungan1` FOREIGN KEY (`no_rekening`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `deposito`
--

LOCK TABLES `deposito` WRITE;
/*!40000 ALTER TABLE `deposito` DISABLE KEYS */;
INSERT INTO `deposito` VALUES ('2023011623210001','23099012321','2023-04-16 21:12:16',90000,0,0,4500,'proses cair','2023-01-16 21:12:16','2023-01-16 21:14:01',1,NULL,'',4,2,7,3);
/*!40000 ALTER TABLE `deposito` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `employee`
--

DROP TABLE IF EXISTS `employee`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `employee` (
  `id` int(11) NOT NULL,
  `nama_depan` varchar(45) NOT NULL,
  `nama_keluarga` varchar(45) DEFAULT NULL,
  `nik` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `position_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_employee_position1_idx` (`position_id`),
  CONSTRAINT `fk_employee_position1` FOREIGN KEY (`position_id`) REFERENCES `position` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `employee`
--

LOCK TABLES `employee` WRITE;
/*!40000 ALTER TABLE `employee` DISABLE KEYS */;
INSERT INTO `employee` VALUES (1,'Doni','Aditya','0303030505950001','doni.adi@gmail.com','45678912','2023-01-14 00:00:00','2023-01-14 00:00:00',1),(2,'Edi','Pranomo','0505050707970001','edi.pra@gmail.com','78912345','2023-01-14 00:00:00','2023-01-14 00:00:00',2);
/*!40000 ALTER TABLE `employee` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `faq`
--

DROP TABLE IF EXISTS `faq`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `faq` (
  `No` int(11) NOT NULL,
  `pertanyaan` varchar(1000) DEFAULT NULL,
  `jawaban` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `faq`
--

LOCK TABLES `faq` WRITE;
/*!40000 ALTER TABLE `faq` DISABLE KEYS */;
INSERT INTO `faq` VALUES (1,'Apa itu aplikasi DiBa?','igital Bank (DiBa) merupakan aplikasi yang membantu kebutuhan anak muda dalam menabung dan mengatur finansial secara digital. DiBa dikemas dengan gaya milenial agar menarik pengguna dari usia pekerja muda dalam mengatur kebutuhan finansial pengguna.'),(2,'Apa saja yang menjadi fitur utama pada aplikasi Diba?','DiBa menawarkan berbagai fitur seperti tabungan, deposito, top up, transaksi, transfer, profil dan setting data untuk membantu kebutuhan anak muda dalam menabung dan mengatur finansial secara digital.'),(3,'Bagaimana cara mendaftar akun pada aplikasi DiBa?','Pada saat membuka aplikasi DiBa, pada Form Login tekan “Don’t have account?”, kemudian anda akan diarahkan untuk mengisi Form Buat Akun, jika seluruh data sudah diisi selanjutnya tekan Register, akun anda telah terdaftar dalam aplikasi DiBa dan an...'),(4,'Bagaimana cara mengganti password akun pada aplikasi DiBa ?','Pada saat membuka aplikasi DiBa, pada Form Utama, tekan Rekening => Deposito => Buat Deposito, kemudian anda akan diarahkan pada Form Deposito Baru, lengkapi data dengan nominal deposito serta jatuh tempo yang diinginkan, tekan tombol Buat Deposito. Depo...'),(5,'Bagaimana cara membuat deposito baru pada aplikasi DiBa ?','Pada saat membuka aplikasi DiBa, pada Form Utama, tekan Rekening => Deposito => Buat Deposito, kemudian anda akan diarahkan pada Form Deposito Baru, lengkapi data dengan nominal deposito serta jatuh tempo yang diinginkan, tekan tombol Buat Deposito. Depo...'),(6,'Bagaimana cara mencairkan deposito pada aplikasi DiBa','Pada saat membuka aplikasi DiBa, pada Form Utama, tekan Rekening => Deposito => Cairkan Deposito, kemudian anda akan diarahkan pada Form Pencarian Deposito, lengkapi data dengan Nomor Deposito serta Tanggal Pengajuan kemudian tekan tombol Process. Deposi...'),(7,'Bagaimana cara top up pada aplikasi DiBa','Pada saat membuka aplikasi DiBa, pada Form Utama, tekan Transaksi => Top Up, kemudian anda akan diarahkan pada Form Top Up, kemudian pada text box nominal anda dapat mengisikan jumlah nominal yang diinginkan, setelah itu tekan tombol Top Up. Proses top up telah berhasil dilakukan.');
/*!40000 ALTER TABLE `faq` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fotoprofil`
--

DROP TABLE IF EXISTS `fotoprofil`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fotoprofil` (
  `id` int(11) NOT NULL,
  `foto` varchar(45) NOT NULL,
  `tgl_upload` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fotoprofil`
--

LOCK TABLES `fotoprofil` WRITE;
/*!40000 ALTER TABLE `fotoprofil` DISABLE KEYS */;
INSERT INTO `fotoprofil` VALUES (1,'joyfulboy','2022-01-01 00:00:00'),(2,'mrbeard','2022-01-01 00:00:00'),(3,'mrworker','2022-01-01 00:00:00'),(4,'mcsporty','2022-01-01 00:00:00'),(5,'mscreative','2022-01-01 00:00:00'),(6,'safetyman','2022-01-01 00:00:00');
/*!40000 ALTER TABLE `fotoprofil` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inbox`
--

DROP TABLE IF EXISTS `inbox`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inbox` (
  `id_pesan` int(11) NOT NULL,
  `id_pengguna` varchar(16) NOT NULL,
  `pesan` varchar(1000) DEFAULT NULL,
  `status` enum('baru','dibaca') DEFAULT NULL,
  `tgl_kirim` datetime NOT NULL,
  `tgl_baca` datetime NOT NULL,
  PRIMARY KEY (`id_pesan`,`id_pengguna`),
  KEY `fk_inbox_pengguna_idx` (`id_pengguna`),
  CONSTRAINT `fk_inbox_pengguna` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inbox`
--

LOCK TABLES `inbox` WRITE;
/*!40000 ALTER TABLE `inbox` DISABLE KEYS */;
INSERT INTO `inbox` VALUES (1,'0202020909950001','Bunga Rekening ( 15/01/2023 15:31:34 )','baru','2023-01-15 15:31:34','2023-01-15 15:31:34'),(2,'0202020909950001','Pajak Bunga Rekening ( 15/01/2023 15:31:34 )','baru','2023-01-15 15:31:34','2023-01-15 15:31:34'),(3,'0202020909950001','Transfer dari 23099012321 sebesar Rp 800000 telah masuk !','baru','2023-01-16 15:39:14','2023-01-16 15:39:14'),(4,'1','Top Up sebesar Rp 3400 telah masuk !','baru','2023-01-16 15:42:04','2023-01-16 15:42:04'),(5,'1','Top Up sebesar Rp 9500 telah masuk !','baru','2023-01-16 19:57:35','2023-01-16 19:57:35'),(6,'3','pembayaran sebesar Rp 85500 telah masuk !','baru','2023-01-16 20:52:00','2023-01-16 20:52:00'),(7,'0','Top Up sebesar Rp 10500 telah masuk !','baru','2023-01-16 21:05:00','2023-01-16 21:05:00'),(8,'2101012002020001','Deposito dengan ID 2023011623210001 telah aktif! Tanggal jatuh tempo pada 16 April 2023 21:12','baru','2023-01-16 21:13:04','2023-01-16 21:13:04'),(9,'0','Top Up sebesar Rp 22500 telah masuk !','baru','2023-01-16 21:22:55','2023-01-16 21:22:55');
/*!40000 ALTER TABLE `inbox` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `jenistransaksi`
--

DROP TABLE IF EXISTS `jenistransaksi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `jenistransaksi` (
  `id` int(11) NOT NULL,
  `kode` varchar(45) NOT NULL,
  `nama` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `jenistransaksi`
--

LOCK TABLES `jenistransaksi` WRITE;
/*!40000 ALTER TABLE `jenistransaksi` DISABLE KEYS */;
INSERT INTO `jenistransaksi` VALUES (1,'DBT','Debit'),(2,'CRT','Kredit'),(3,'TAX','Tax'),(4,'ITR','Interest');
/*!40000 ALTER TABLE `jenistransaksi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kodepromo`
--

DROP TABLE IF EXISTS `kodepromo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kodepromo` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `nominal_potongan` double DEFAULT NULL,
  `persen_potongan` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kodepromo`
--

LOCK TABLES `kodepromo` WRITE;
/*!40000 ALTER TABLE `kodepromo` DISABLE KEYS */;
INSERT INTO `kodepromo` VALUES (0,'',0,0),(1,'DISKONSBY',10000,5);
/*!40000 ALTER TABLE `kodepromo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pengguna`
--

DROP TABLE IF EXISTS `pengguna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pengguna` (
  `nik` varchar(16) NOT NULL,
  `nama_depan` varchar(45) DEFAULT NULL,
  `nama_keluarga` varchar(45) DEFAULT NULL,
  `alamat` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `no_telp` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `pin` varchar(45) DEFAULT NULL,
  `tgl_buat` datetime DEFAULT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `total_poin` int(11) DEFAULT NULL,
  `foto_id` int(11) DEFAULT NULL,
  `tipe_pengguna` int(11) DEFAULT NULL,
  PRIMARY KEY (`nik`),
  KEY `fk_pengguna_foto1_idx` (`foto_id`),
  KEY `fk_pengguna_tipePengguna1_idx` (`tipe_pengguna`),
  CONSTRAINT `fk_pengguna_foto1` FOREIGN KEY (`foto_id`) REFERENCES `fotoprofil` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_pengguna_tipePengguna1` FOREIGN KEY (`tipe_pengguna`) REFERENCES `tipepengguna` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pengguna`
--

LOCK TABLES `pengguna` WRITE;
/*!40000 ALTER TABLE `pengguna` DISABLE KEYS */;
INSERT INTO `pengguna` VALUES ('0','OVO','DibaAccount','jl','OVO','0','1','1','2022-01-01 00:00:00','2022-01-01 00:00:00',0,1,4),('0202020909950001','Budi','Lianto','Jalan Kalimantan No.1','budi.lia@gmai.com','081234567891','budiLianto123','987654','2023-01-14 00:00:00','2023-01-14 00:00:00',0,5,1),('1','ShopeePay','DibaAccount','jl','SHOPEEPAY','0','1','1','2022-01-01 00:00:00','2022-01-01 00:00:00',0,1,4),('2','Gopay','DibaAccount','jl','GOPAY','0','1','1','2022-01-01 00:00:00','2022-01-01 00:00:00',0,1,4),('2009989098712562','sela','breaz','jl.prapen no1','sela@gmail.com','081909876521','sela123','123456','2023-01-16 15:58:53','2023-01-16 15:58:53',0,1,1),('2101012002020001','Andi','Hermawan','Jalan Sumatra No.1','andi.her@gmai.com','081122223333','12345678','654321','2023-01-14 00:00:00','2023-01-14 00:00:00',0,5,1),('3','PLN','DibaAccount','jl','PLN','0','1','1','2022-01-01 00:00:00','2022-01-01 00:00:00',0,1,4),('4','PDAM','DibaAccount','jl','PDAM','0','1','1','2022-01-01 00:00:00','2022-01-01 00:00:00',0,1,4);
/*!40000 ALTER TABLE `pengguna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `position`
--

DROP TABLE IF EXISTS `position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `position` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `position`
--

LOCK TABLES `position` WRITE;
/*!40000 ALTER TABLE `position` DISABLE KEYS */;
INSERT INTO `position` VALUES (1,'Admin',NULL),(2,'Keuangan',NULL);
/*!40000 ALTER TABLE `position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tabungan`
--

DROP TABLE IF EXISTS `tabungan`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tabungan` (
  `no_rekening` varchar(11) NOT NULL,
  `id_pengguna` varchar(16) DEFAULT NULL,
  `saldo` double NOT NULL,
  `status` enum('aktif','unverified','suspend','nonaktif') NOT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `tgl_buat` datetime NOT NULL,
  `tgl_perubahan` datetime DEFAULT NULL,
  `verifikator` int(11) DEFAULT NULL,
  `limit_transfer` double DEFAULT NULL,
  PRIMARY KEY (`no_rekening`),
  KEY `fk_tabungan_pengguna1_idx` (`id_pengguna`),
  KEY `fk_tabungan_employee1_idx` (`verifikator`),
  CONSTRAINT `fk_tabungan_employee1` FOREIGN KEY (`verifikator`) REFERENCES `employee` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_tabungan_pengguna1` FOREIGN KEY (`id_pengguna`) REFERENCES `pengguna` (`nik`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tabungan`
--

LOCK TABLES `tabungan` WRITE;
/*!40000 ALTER TABLE `tabungan` DISABLE KEYS */;
INSERT INTO `tabungan` VALUES ('00000000000','0',33000,'aktif','OVO','2022-01-01 00:00:00','2022-01-01 00:00:00',1,1000000),('11111111111','1',12900,'aktif','ShopeePay','2022-01-01 00:00:00','2022-01-01 00:00:00',1,1000000),('20230116001','2009989098712562',0,'aktif',NULL,'2023-01-16 15:58:53','2023-01-16 15:58:53',NULL,10000000),('22222222222','2',0,'aktif','Gopay','2022-01-01 00:00:00','2022-01-01 00:00:00',1,1000000),('23099012321','2101012002020001',98978600,'aktif',NULL,'2023-01-14 00:00:00','2023-01-14 00:00:00',1,1000000),('33333333333','3',85500,'aktif','PLN','2022-01-01 00:00:00','2022-01-01 00:00:00',1,1000000),('44444444444','4',0,'aktif','PDAM','2022-01-01 00:00:00','2022-01-01 00:00:00',1,1000000),('98099876781','0202020909950001',1000597,'aktif',NULL,'2023-01-14 00:00:00','2023-01-14 00:00:00',1,10000000);
/*!40000 ALTER TABLE `tabungan` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipepengguna`
--

DROP TABLE IF EXISTS `tipepengguna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tipepengguna` (
  `id` int(11) NOT NULL,
  `nama` varchar(45) NOT NULL,
  `minimal_poin` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipepengguna`
--

LOCK TABLES `tipepengguna` WRITE;
/*!40000 ALTER TABLE `tipepengguna` DISABLE KEYS */;
INSERT INTO `tipepengguna` VALUES (1,'Bronze',0),(2,'Silver',1000),(3,'Gold',5000),(4,'Platinum',10000);
/*!40000 ALTER TABLE `tipepengguna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaksi`
--

DROP TABLE IF EXISTS `transaksi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `rekening_sumber` varchar(11) NOT NULL,
  `tgl_transaksi` varchar(45) NOT NULL,
  `nominal` double NOT NULL,
  `poin_dapat` int(11) DEFAULT NULL,
  `keterangan` varchar(45) DEFAULT NULL,
  `jenisTransaksi_id` int(11) NOT NULL,
  `rekening_tujuan` varchar(11) NOT NULL,
  `kodePromo_id` int(11) DEFAULT NULL,
  `diskon` double DEFAULT NULL,
  PRIMARY KEY (`id_transaksi`),
  KEY `fk_transaksi_jenisTransaksi1_idx` (`jenisTransaksi_id`),
  KEY `fk_transaksi_tabungan1_idx` (`rekening_tujuan`),
  KEY `fk_transaksi_tabungan2_idx` (`rekening_sumber`),
  KEY `fk_transaksi_kodePromo1_idx` (`kodePromo_id`),
  CONSTRAINT `fk_transaksi_jenisTransaksi1` FOREIGN KEY (`jenisTransaksi_id`) REFERENCES `jenistransaksi` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksi_kodePromo1` FOREIGN KEY (`kodePromo_id`) REFERENCES `kodepromo` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksi_tabungan1` FOREIGN KEY (`rekening_tujuan`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transaksi_tabungan2` FOREIGN KEY (`rekening_sumber`) REFERENCES `tabungan` (`no_rekening`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaksi`
--

LOCK TABLES `transaksi` WRITE;
/*!40000 ALTER TABLE `transaksi` DISABLE KEYS */;
INSERT INTO `transaksi` VALUES (1,'98099876781','2023-01-15 15:31:34',597,0,'Bunga Rekening ( 15/01/2023 15:31:34 )',4,'98099876781',0,0),(2,'98099876781','2023-01-15 15:31:34',0,0,'Pajak Bunga Rekening ( 15/01/2023 15:31:34 )',3,'98099876781',0,0),(3,'23099012321','16/01/2023 15:39:14',800000,0,'tf coba',1,'98099876781',0,0),(4,'98099876781','16/01/2023 15:39:14',800000,0,'tf coba',2,'98099876781',0,0),(5,'23099012321','16/01/2023 21:22:55',22500,2,'Top Up OVO Nomor : 081122223333',1,'00000000000',0,0),(6,'00000000000','16/01/2023 21:22:55',22500,0,'Top Up OVO Nomor : 081122223333',2,'00000000000',0,0);
/*!40000 ALTER TABLE `transaksi` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-01-16 21:24:26
