-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Okt 01. 12:55
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `etterem`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `rendeles`
--

CREATE DATABASE etterem;
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

CREATE TABLE `rendeles` (
  `Id` int(11) NOT NULL,
  `Dish` varchar(40) NOT NULL,
  `Description` text NOT NULL,
  `OrderTime` datetime NOT NULL,
  `UpdateTime` datetime NOT NULL,
  `VendegId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `rendeles`
--

INSERT INTO `rendeles` (`Id`, `Dish`, `Description`, `OrderTime`, `UpdateTime`, `VendegId`) VALUES
(1, 'Gulyásleves', 'Extra csípős kérésre, kenyérrel.', '2025-05-02 12:30:00', '2025-05-02 12:30:00', 1),
(2, 'Rántott sajt', 'Hasábburgonyával és tartármártással.', '2025-05-14 19:15:00', '2025-05-14 19:15:00', 2),
(3, 'Halászlé', 'Szegedi módra, csípős paprikával.', '2025-05-26 13:00:00', '2025-05-26 13:00:00', 3),
(4, 'Túrós csusza', 'Tepertővel, dupla adag tejföllel.', '2025-06-08 20:40:00', '2025-06-08 20:40:00', 5),
(5, 'Somlói galuska', 'Desszert, extra csokiöntettel.', '2025-06-19 21:20:00', '2025-06-19 21:20:00', 6);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vendeg`
--

CREATE TABLE `vendeg` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `email` varchar(100) NOT NULL,
  `age` int(11) NOT NULL,
  `password` varchar(100) NOT NULL,
  `registrationTime` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `vendeg`
--

INSERT INTO `vendeg` (`id`, `name`, `email`, `age`, `password`, `registrationTime`) VALUES
(1, 'Németh Boglárka', 'nemeth.boglarka@example.com', 27, 'etterem1!', '2025-01-08 18:30:00'),
(2, 'Farkas Ábel', 'farkas.abel@example.com', 31, 'vacsora25', '2025-02-01 19:00:00'),
(3, 'Juhász Emese', 'juhasz.emese@example.com', 24, 'menu2025', '2025-02-19 20:15:00'),
(4, 'Orsós Kende', 'orsos.kende@example.com', 29, 'asztal12', '2025-03-10 17:45:00'),
(5, 'Rácz Hanna', 'racz.hanna@example.com', 26, 'pincer99', '2025-03-27 21:05:00'),
(6, 'Tamás Botond', 'tamas.botond@example.com', 33, 'foglalas7', '2025-04-15 18:50:00');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `rendeles`
--
ALTER TABLE `rendeles`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `VendegId` (`VendegId`);

--
-- A tábla indexei `vendeg`
--
ALTER TABLE `vendeg`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `rendeles`
--
ALTER TABLE `rendeles`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT a táblához `vendeg`
--
ALTER TABLE `vendeg`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `rendeles`
--
ALTER TABLE `rendeles`
  ADD CONSTRAINT `rendeles_ibfk_1` FOREIGN KEY (`VendegId`) REFERENCES `vendeg` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
