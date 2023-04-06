-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 06.04.2023 klo 11:42
-- Palvelimen versio: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pc_superstore`
--

-- --------------------------------------------------------

--
-- Rakenne taululle `kayttajat`
--

CREATE TABLE `kayttajat` (
  `kayttajatunnus` varchar(25) NOT NULL,
  `salasana` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `oikeudet` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Vedos taulusta `kayttajat`
--

INSERT INTO `kayttajat` (`kayttajatunnus`, `salasana`, `email`, `oikeudet`) VALUES
('admin', 'admin', '', 1),
('janne', 'kataja', 'janne.kataja@mtv.fi', 2),
('paavo', 'pesusieni', 'paavo.pesusieni@nelonen.fi', 2),
('pertti', 'salis', 'pertti.pasanen@gmail.com', 2),
('Petnur', 'petrinsalis', 'petri.nurmi@hotmaill.com', 2),
('vierailija', 'vierailija', '', 2);

-- --------------------------------------------------------

--
-- Rakenne taululle `komponentit`
--

CREATE TABLE `komponentit` (
  `tuote` varchar(100) NOT NULL,
  `tuotekategoria` varchar(50) NOT NULL,
  `saldo` int(6) NOT NULL,
  `hinta` int(6) NOT NULL,
  `tuotetiedot` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Vedos taulusta `komponentit`
--

INSERT INTO `komponentit` (`tuote`, `tuotekategoria`, `saldo`, `hinta`, `tuotetiedot`) VALUES
('AMD Ryzen 9 7950X3D, AM5, 4.2 GHz, 16-Core, WOF', 'prosessorit', 25, 820, 'Äärimmäinen prosessori pelaamiseen, jonka AMD 3D V-Cache -teknologia tarjoaa aiempaa enemmän pelisuorituskykyä!'),
('asus rog strix 4080 12gb', 'näytönohjaimet', 25, 1400, 'NVIDIA® GeForce RTX® 40 -sarjan grafiikkasuorittimet tarjoavat pelaajille ja luovan työntekijöille paljon muutakin kuin huippunopean grafiikan. Niiden teho on peräisin ultratehokkaasta NVIDIA Ada Lovelace -arkkitehtuurista, joka edustaa suoranaista kvanttiloikkaa suorituskyvyssä ja grafiikan tekoälytehostuksessa. Säteenseurannan ja ultrasuurten FPS-pelinopeuksien ansiosta pääset kokemaan virtuaaliset maailmat todella elävän tuntuisina. Pääset myös tutustumaan mullistaviin uusiin tapoihin luoda ja nopeuttaa työnkulkuja.'),
('ROG STRIX X670E-F GAMING WIFI, ATX-emolevy', 'emolevyt', 25, 399, 'Prosessorituki:\r\nAMD AM5 -kanta\r\nTukee AMD Ryzen 7000 -sarjan työpöytäprosessoreja'),
('Samsung 1TB 980 PRO SSD-levy', 'kovalevyt', 25, 129, 'Samsung PCIe 4.0 NVMe SSD 980 PRO antaa tehoa, jolla viet tietokoneen käytön seuraavalle tasolle. 980 PRO:n PCIe 4.0 -liitäntä merkitsee kaksinkertaista tiedonsiirtonopeutta PCIe 3.0 -liitäntään verrattuna.');

-- --------------------------------------------------------

--
-- Rakenne taululle `oheistuotteet`
--

CREATE TABLE `oheistuotteet` (
  `tuote` varchar(100) NOT NULL,
  `tuotekategoria` varchar(50) NOT NULL,
  `saldo` int(6) NOT NULL,
  `hinta` int(6) NOT NULL,
  `tuotetiedot` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Vedos taulusta `oheistuotteet`
--

INSERT INTO `oheistuotteet` (`tuote`, `tuotekategoria`, `saldo`, `hinta`, `tuotetiedot`) VALUES
('Logitech G PRO X Gaming Headset', 'kuulokkeet', 25, 90, 'ENCE e-sports joukkueen suosittelema Logitech tuote.'),
('Logitech G502 HERO, optinen pelihiiri, 25 000 dpi, musta', 'hiiret', 25, 70, 'Logitechin G502 uudella HERO sensorilla takaa sen, että sinulla on kaikki mitä voittamiseen vaaditaan. \r\n\r\nHERO on tarkin koskaan Logitechin valmistama pelitunnistin. Siinä on seuraavan sukupolven tarkkuus ja kokonaan uusiksi suunniteltu arkkitehtuuri.\r\n\r\nToistaiseksi nopeimman kuvataajuudenkäsittelyn ansiosta HERO kykenee yli 400 IPS:ään koko 100–25 000 DPI:n välillä, eikä siinä ole lainkaan tasoitusta, suodatusta tai kiihdytystä. HERO saavuttaa kilpatason tarkkuuden ja kaikkien aikojen yhdenmukaisimmat vasteajat. \r\n\r\nMuista mukauttaa ja optimoida DPI-asetukset Logitech Gaming Softwarella (LGS).'),
('Logitech PRO, mekaaninen Tenkeyless-pelinäppäimistö', 'näppäimistöt', 25, 118, 'Mekaaninen Logitech G® PRO -pelinäppäimistö on suunniteltu e-urheilijoiden kanssa e-urheilijoita varten. Se on pienikokoinen eikä siinä ole lainkaan numeronäppäimistöä, joten pöydällä on hyvin tilaa hiiren liikkeille alhaisilla herkkyysasetuksilla.');

-- --------------------------------------------------------

--
-- Rakenne taululle `tietokoneet`
--

CREATE TABLE `tietokoneet` (
  `tuote` varchar(100) NOT NULL,
  `tuotekategoria` varchar(50) NOT NULL,
  `saldo` int(6) NOT NULL,
  `hinta` int(6) NOT NULL,
  `tuotetiedot` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Vedos taulusta `tietokoneet`
--

INSERT INTO `tietokoneet` (`tuote`, `tuotekategoria`, `saldo`, `hinta`, `tuotetiedot`) VALUES
('Asus 15,6\" ROG Zephyrus G15 GA503RM', 'kannettavat', 25, 2099, 'Ominaisuudet:\r\n\r\nAMD Ryzen 7 6800HS, 16 Gt, 1 Tt SSD\r\n15,6\" WQHD 3ms 240 Hz -IPS-näyttö\r\nNVIDIA GeForce RTX 3060\r\nMUX switch\r\nUusi DDR5 muisti & WiFi 6E tekniikka'),
('Asus 15,6\" TUF Gaming F15 FX507ZM, kannettava pelitietokone', 'kannettavat', 24, 1797, 'Ominaisuudet:\r\n\r\n- Käyttöjärjestelmä: Windows 11 Home\r\n- Näyttö: 15,6\", Anti-Glare, IPS, 144Hz, \r\n  1920 x 1080\r\n- Prosessori: Intel Core i7-12700H, 24MB, \r\n  14-core (6 P + 8 E)\r\n- Näytönohjain: NVIDIA® GeForce RTX™ 3060 \r\n  Laptop GPU, 6GB GDDR6 (1752MHz at 140W \r\n  (1702MHz Boost Clock+50MHz OC, 115W+25W \r\n  Dynamic Boost))\r\n- Muisti: 16GB (2 x 8GB) DDR5-4800 SO- \r\n  DIMM\r\n- Kiintolevy: 1TB SSD (PCIe 3.0 NVMe M.2)\r\n  Optinen asema: Ei\r\n- 4G/LTE-modeemi: Ei\r\n  WLAN: Wi-Fi 6 (802.11ax) (Dual band) \r\n  2*2\r\n- Bluetooth: 5.1\r\n- Kortinlukija: Ei\r\n'),
('Jimm\'s Meshify 4090', 'pöytäkoneet', 25, 4700, 'Ominaisuudet:\r\n\r\n- Prosessori: Intel Core i9-13900K, \r\n  3.0/5.8 GHz\r\n- Emolevy: ASUS Intel Z790 -piirisarjaan \r\n  pohjautuva\r\n- Näytönohjain: ASUS NVIDIA Geforce RTX \r\n  4090, 24GB GDDR6X\r\n- Keskusmuisti: 32GB (2 x 16GB) RGB DDR5 \r\n  5600MHz\r\n- Massamuisti: 1TB M.2 NVMe SSD\r\n- Optinen asema: - (HUOM! Kotelossa ei \r\n  ole paikkaa sisäiselle optiselle \r\n  asemalle!)\r\n- Prosessorijäähdytys: Lian Li - GALAHAD \r\n  360 SL V2, AIO-nestejäähdytys, \r\n  valkoinen\r\n- Kotelo: Fractal Design - Meshify 2 \r\n  White, TG Clear Tint, valkoinen\r\n- Virtalähde: Corsair 1200W 80+ Platinum\r\n- Käyttöjärjestelmä: Windows 11 Home\r\n- Muuta: Wi-Fi & Bluetooth, 3 x Lian Li \r\n  SL140 RGB tuulettimet, Lian Li \r\n  näytönohjaintuki'),
('Jimm\'s Pro Gamer Vishnu 3070', 'pöytäkoneet', 25, 1900, 'Ominsaisuudet:\r\n\r\n- Prosessori: AMD Ryzen 7 5800X, 3.8/4.7 \r\n  GHz\r\n- Emolevy: ASUS AMD B550 -piirisarjaan \r\n  pohjautuva\r\n- Näytönohjain: ASUS NVIDIA Geforce RTX \r\n  3070, 8GB GDDR6\r\n- Keskusmuisti: 16GB (2 x 8GB) DDR4 \r\n  3600MHz\r\n- Massamuisti: 1TB M.2 NVMe SSD\r\n- Optinen asema: - (HUOM! Kotelossa ei \r\n  ole paikkaa sisäiselle optiselle \r\n  asemalle!)\r\n- Prosessorijäähdytys: Alpenföhn Dolomit \r\n  Advanced\r\n- Kotelo: Kolink Castle\r\n- Virtalähde: 750W 80+ Gold\r\n- Käyttöjärjestelmä: Windows 11 Home');

-- --------------------------------------------------------

--
-- Rakenne taululle `tilaukset`
--

CREATE TABLE `tilaukset` (
  `tilausnro` int(50) NOT NULL,
  `etunimi` varchar(25) NOT NULL,
  `sukunimi` varchar(50) NOT NULL,
  `puhelin` varchar(15) NOT NULL,
  `sähköposti` varchar(50) NOT NULL,
  `katuosoite` varchar(50) NOT NULL,
  `postinumero` varchar(5) NOT NULL,
  `tilaus` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Vedos taulusta `tilaukset`
--

INSERT INTO `tilaukset` (`tilausnro`, `etunimi`, `sukunimi`, `puhelin`, `sähköposti`, `katuosoite`, `postinumero`, `tilaus`) VALUES
(2, 'hgtsh', 'shhsfh', '6546456', 'hsfgh', 'hsth', 'sthh', '');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `kayttajat`
--
ALTER TABLE `kayttajat`
  ADD PRIMARY KEY (`kayttajatunnus`);

--
-- Indexes for table `komponentit`
--
ALTER TABLE `komponentit`
  ADD PRIMARY KEY (`tuote`);

--
-- Indexes for table `oheistuotteet`
--
ALTER TABLE `oheistuotteet`
  ADD PRIMARY KEY (`tuote`);

--
-- Indexes for table `tietokoneet`
--
ALTER TABLE `tietokoneet`
  ADD PRIMARY KEY (`tuote`);

--
-- Indexes for table `tilaukset`
--
ALTER TABLE `tilaukset`
  ADD PRIMARY KEY (`tilausnro`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tilaukset`
--
ALTER TABLE `tilaukset`
  MODIFY `tilausnro` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
