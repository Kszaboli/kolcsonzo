-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Már 10. 08:15
-- Kiszolgáló verziója: 10.4.20-MariaDB
-- PHP verzió: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kolcsonzo`
--
CREATE DATABASE IF NOT EXISTS `kolcsonzo` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `kolcsonzo`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cars`
--

CREATE TABLE `cars` (
  `Id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Marka` varchar(255) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Model` varchar(255) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Evjarat` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `customers`
--

CREATE TABLE `customers` (
  `Id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Name` varchar(255) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(255) COLLATE utf8mb4_hungarian_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rents`
--

CREATE TABLE `rents` (
  `Id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Customer_id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Car_id` varchar(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Start` date NOT NULL,
  `End` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
