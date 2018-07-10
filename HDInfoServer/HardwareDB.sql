-- phpMyAdmin SQL Dump
-- version 4.7.3
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Июн 16 2018 г., 01:28
-- Версия сервера: 5.7.19
-- Версия PHP: 7.0.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `HardwareDB`
--

-- --------------------------------------------------------

--
-- Структура таблицы `BaseBoards`
--

CREATE TABLE `BaseBoards` (
  `id` int(11) NOT NULL,
  `product` varchar(100) NOT NULL,
  `manufacturer` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `BaseBoards`
--

INSERT INTO `BaseBoards` (`id`, `product`, `manufacturer`, `computer_id`) VALUES
(1, 'TH55 HD', 'BIOSTAR Group', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `Bios`
--

CREATE TABLE `Bios` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `biosVersion` varchar(100) NOT NULL,
  `language` varchar(100) NOT NULL,
  `manufacturer` varchar(100) NOT NULL,
  `serialNumber` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Bios`
--

INSERT INTO `Bios` (`id`, `name`, `biosVersion`, `language`, `manufacturer`, `serialNumber`, `computer_id`) VALUES
(1, 'Default System BIOS', '010710 - 20100107 ', 'en|US|iso8859-1', 'American Megatrends Inc.', 'None', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `ChangesHistory`
--

CREATE TABLE `ChangesHistory` (
  `id` int(11) NOT NULL,
  `deviceType` varchar(100) NOT NULL,
  `deviceID` int(11) NOT NULL,
  `header` varchar(100) NOT NULL,
  `valueBefore` varchar(100) NOT NULL,
  `valueAfter` varchar(100) NOT NULL,
  `changeSubmit` varchar(100) NOT NULL,
  `updatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `ChangesHistory`
--

INSERT INTO `ChangesHistory` (`id`, `deviceType`, `deviceID`, `header`, `valueBefore`, `valueAfter`, `changeSubmit`, `updatedAt`, `computer_id`) VALUES
(3, 'PhysicalMemories', 1, 'Name', ' ', 'Физическая память', 'Подтверждено', '2018-06-15 23:45:28', 20),
(4, 'PhysicalMemories', 1, 'BankLabel', ' ', 'BANK0', 'Подтверждено', '2018-06-15 23:45:28', 20),
(5, 'PhysicalMemories', 1, 'Capacity', ' ', '2147483648', 'Подтверждено', '2018-06-15 23:45:28', 20),
(6, 'PhysicalMemories', 1, 'Manufacturer', ' ', 'Manufacturer00', 'Подтверждено', '2018-06-15 23:45:28', 20),
(7, 'PhysicalMemories', 1, 'DataWidth', ' ', '64', 'Подтверждено', '2018-06-15 23:45:28', 20),
(8, 'PhysicalMemories', 2, 'Name', ' ', 'Физическая память', 'Подтверждено', '2018-06-15 23:45:28', 20),
(9, 'PhysicalMemories', 2, 'BankLabel', ' ', 'BANK1', 'Подтверждено', '2018-06-15 23:45:28', 20),
(10, 'PhysicalMemories', 2, 'Capacity', ' ', '2147483648', 'Подтверждено', '2018-06-15 23:45:28', 20),
(11, 'PhysicalMemories', 2, 'Manufacturer', ' ', 'Manufacturer01', 'Подтверждено', '2018-06-15 23:45:28', 20),
(12, 'PhysicalMemories', 2, 'DataWidth', ' ', '64', 'Подтверждено', '2018-06-15 23:45:28', 20),
(13, 'PhysicalMemories', 3, 'Name', ' ', 'Физическая память', 'Подтверждено', '2018-06-15 23:45:28', 20),
(14, 'PhysicalMemories', 3, 'BankLabel', ' ', 'BANK2', 'Подтверждено', '2018-06-15 23:45:28', 20),
(15, 'PhysicalMemories', 3, 'Capacity', ' ', '2147483648', 'Подтверждено', '2018-06-15 23:45:28', 20),
(16, 'PhysicalMemories', 3, 'Manufacturer', ' ', 'Manufacturer02', 'Подтверждено', '2018-06-15 23:45:28', 20),
(17, 'PhysicalMemories', 3, 'DataWidth', ' ', '64', 'Подтверждено', '2018-06-15 23:45:28', 20),
(18, 'PhysicalMemories', 4, 'Name', ' ', 'Физическая память', 'Подтверждено', '2018-06-15 23:45:28', 20),
(19, 'PhysicalMemories', 4, 'BankLabel', ' ', 'BANK3', 'Подтверждено', '2018-06-15 23:45:28', 20),
(20, 'PhysicalMemories', 4, 'Capacity', ' ', '2147483648', 'Подтверждено', '2018-06-15 23:45:28', 20),
(21, 'PhysicalMemories', 4, 'Manufacturer', ' ', 'Manufacturer03', 'Подтверждено', '2018-06-15 23:45:28', 20),
(22, 'PhysicalMemories', 4, 'DataWidth', ' ', '64', 'Подтверждено', '2018-06-15 23:45:28', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `Computers`
--

CREATE TABLE `Computers` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `status` varchar(100) NOT NULL,
  `updatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `room_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Computers`
--

INSERT INTO `Computers` (`id`, `name`, `status`, `updatedAt`, `room_id`) VALUES
(2, 'Comp1', 'Подтвержден', '2018-06-10 20:35:36', 2),
(3, 'Comp2', 'Подтвержден', '2018-06-10 20:36:16', 1),
(4, 'Comp3', 'Не подтвержден', '2018-06-10 20:36:16', 1),
(5, 'Comp4', 'Подтвержден', '2018-06-10 20:36:16', 1),
(6, 'testcomp', 'Подтвержден', '2018-06-14 09:00:43', 1),
(7, 'testcomp2', 'Подтвержден', '2018-06-14 09:01:39', 2),
(8, 'testcomp3', 'Подтвержден', '2018-06-14 09:03:23', 2),
(9, 'testcomp4', 'Подтвержден', '2018-06-14 09:04:36', 2),
(10, 'testcomp6', 'Подтвержден', '2018-06-14 09:17:21', 3),
(11, 'testcomp6', 'Подтвержден', '2018-06-14 09:19:08', 3),
(12, 'testcomp6', 'Подтвержден', '2018-06-15 20:37:23', 3),
(13, 'testcomp6', 'Подтвержден', '2018-06-15 20:41:28', 3),
(14, 'testcomp6', 'Подтвержден', '2018-06-14 09:27:40', 3),
(15, 'testcomp6', 'Подтвержден', '2018-06-14 09:30:52', 3),
(16, 'testcomp6', 'Подтвержден', '2018-06-14 09:32:08', 3),
(17, 'testcomp6', 'Подтвержден', '2018-06-14 09:33:58', 3),
(18, 'testcomp6', 'Подтвержден', '2018-06-15 20:42:38', 3),
(19, 'testcomp6', 'Подтвержден', '2018-06-15 20:45:37', 3),
(20, 'testcomp6', 'Подтвержден', '2018-06-16 01:25:57', 4),
(21, 'Комп-01', 'Подтвержден', '2018-06-16 01:15:56', 7);

-- --------------------------------------------------------

--
-- Структура таблицы `DiskDrivers`
--

CREATE TABLE `DiskDrivers` (
  `id` int(11) NOT NULL,
  `caption` varchar(100) NOT NULL,
  `size` varchar(100) NOT NULL,
  `serialNumber` varchar(100) NOT NULL,
  `manufacturer` varchar(100) NOT NULL,
  `firmwareRev` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `DiskDrivers`
--

INSERT INTO `DiskDrivers` (`id`, `caption`, `size`, `serialNumber`, `manufacturer`, `firmwareRev`, `computer_id`) VALUES
(1, 'WDC WD10EARS-00Y5B1 ATA Device', '1000202273280', '     WD-WCAV5L623303', '(Стандартные дисковые накопители)', '80.00A80', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `NetworkAdapters`
--

CREATE TABLE `NetworkAdapters` (
  `id` int(11) NOT NULL,
  `description` varchar(100) NOT NULL,
  `serviceName` varchar(100) NOT NULL,
  `ipGateway` varchar(100) NOT NULL,
  `dnsServer` varchar(100) NOT NULL,
  `ipAddress` varchar(100) NOT NULL,
  `ipSubnet` varchar(100) NOT NULL,
  `macAddress` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `NetworkAdapters`
--

INSERT INTO `NetworkAdapters` (`id`, `description`, `serviceName`, `ipGateway`, `dnsServer`, `ipAddress`, `ipSubnet`, `macAddress`, `computer_id`) VALUES
(1, 'Realtek PCIe GBE Family Controller', 'rt640x64', '192.168.0.1 ', '192.168.0.1 ', '192.168.0.103 fe80::d139:17ea:6f41:8bf9 ', '255.255.255.0 64 ', '00:30:67:5A:45:41', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `PhysicalMemories`
--

CREATE TABLE `PhysicalMemories` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `bankLabel` varchar(100) NOT NULL,
  `manufacturer` varchar(100) NOT NULL,
  `dataWidth` varchar(100) NOT NULL,
  `capacity` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `PhysicalMemories`
--

INSERT INTO `PhysicalMemories` (`id`, `name`, `bankLabel`, `manufacturer`, `dataWidth`, `capacity`, `computer_id`) VALUES
(1, 'Физическая память', 'BANK0', 'Manufacturer00', '64', '2147483648', 20),
(2, 'Физическая память', 'BANK1', 'Manufacturer01', '64', '2147483648', 20),
(3, 'Физическая память', 'BANK2', 'Manufacturer02', '64', '2147483648', 20),
(4, 'Физическая память', 'BANK3', 'Manufacturer03', '64', '2147483648', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `Processors`
--

CREATE TABLE `Processors` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `description` varchar(100) NOT NULL,
  `addressWidth` varchar(100) NOT NULL,
  `countOfCores` varchar(100) NOT NULL,
  `threadCount` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Processors`
--

INSERT INTO `Processors` (`id`, `name`, `description`, `addressWidth`, `countOfCores`, `threadCount`, `computer_id`) VALUES
(1, 'Intel(R) Core(TM) i3 CPU         540  @ 3.07GHz', 'Intel64 Family 6 Model 37 Stepping 5', '64', '2', '4', 20);

-- --------------------------------------------------------

--
-- Структура таблицы `Rooms`
--

CREATE TABLE `Rooms` (
  `id` int(11) NOT NULL,
  `name` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `Rooms`
--

INSERT INTO `Rooms` (`id`, `name`) VALUES
(1, 'Б-501'),
(2, 'Б-502'),
(3, 'Б-503'),
(4, 'Б-504'),
(5, 'Б-505'),
(6, 'Б-506'),
(7, 'Б-507');

-- --------------------------------------------------------

--
-- Структура таблицы `VideoAdapters`
--

CREATE TABLE `VideoAdapters` (
  `id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `adapterType` varchar(100) NOT NULL,
  `adapterRAM` varchar(100) NOT NULL,
  `deviceID` varchar(100) NOT NULL,
  `computer_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `VideoAdapters`
--

INSERT INTO `VideoAdapters` (`id`, `name`, `adapterType`, `adapterRAM`, `deviceID`, `computer_id`) VALUES
(1, 'NVIDIA GeForce GTX 750', 'Integrated RAMDAC', '1073741824', 'VideoController1', 20);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `BaseBoards`
--
ALTER TABLE `BaseBoards`
  ADD PRIMARY KEY (`id`),
  ADD KEY `BaseBInComputer` (`computer_id`);

--
-- Индексы таблицы `Bios`
--
ALTER TABLE `Bios`
  ADD PRIMARY KEY (`id`),
  ADD KEY `BiosInComputer` (`computer_id`);

--
-- Индексы таблицы `ChangesHistory`
--
ALTER TABLE `ChangesHistory`
  ADD PRIMARY KEY (`id`),
  ADD KEY `HistoryInComputer` (`computer_id`);

--
-- Индексы таблицы `Computers`
--
ALTER TABLE `Computers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `RoomInComputer` (`room_id`);

--
-- Индексы таблицы `DiskDrivers`
--
ALTER TABLE `DiskDrivers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `DiskDInComputer` (`computer_id`);

--
-- Индексы таблицы `NetworkAdapters`
--
ALTER TABLE `NetworkAdapters`
  ADD PRIMARY KEY (`id`),
  ADD KEY `NetAdapterInComputer` (`computer_id`);

--
-- Индексы таблицы `PhysicalMemories`
--
ALTER TABLE `PhysicalMemories`
  ADD PRIMARY KEY (`id`),
  ADD KEY `PhysMemInComputer` (`computer_id`);

--
-- Индексы таблицы `Processors`
--
ALTER TABLE `Processors`
  ADD PRIMARY KEY (`id`),
  ADD KEY `ProcessorInComputer` (`computer_id`);

--
-- Индексы таблицы `Rooms`
--
ALTER TABLE `Rooms`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `VideoAdapters`
--
ALTER TABLE `VideoAdapters`
  ADD PRIMARY KEY (`id`),
  ADD KEY `VideoAdapterInComputer` (`computer_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `BaseBoards`
--
ALTER TABLE `BaseBoards`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `Bios`
--
ALTER TABLE `Bios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `ChangesHistory`
--
ALTER TABLE `ChangesHistory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
--
-- AUTO_INCREMENT для таблицы `Computers`
--
ALTER TABLE `Computers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT для таблицы `DiskDrivers`
--
ALTER TABLE `DiskDrivers`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `NetworkAdapters`
--
ALTER TABLE `NetworkAdapters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `PhysicalMemories`
--
ALTER TABLE `PhysicalMemories`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT для таблицы `Processors`
--
ALTER TABLE `Processors`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT для таблицы `Rooms`
--
ALTER TABLE `Rooms`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT для таблицы `VideoAdapters`
--
ALTER TABLE `VideoAdapters`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `BaseBoards`
--
ALTER TABLE `BaseBoards`
  ADD CONSTRAINT `BaseBInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Bios`
--
ALTER TABLE `Bios`
  ADD CONSTRAINT `BiosInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `ChangesHistory`
--
ALTER TABLE `ChangesHistory`
  ADD CONSTRAINT `HistoryInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Computers`
--
ALTER TABLE `Computers`
  ADD CONSTRAINT `RoomInComputer` FOREIGN KEY (`room_id`) REFERENCES `Rooms` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `DiskDrivers`
--
ALTER TABLE `DiskDrivers`
  ADD CONSTRAINT `DiskDInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `NetworkAdapters`
--
ALTER TABLE `NetworkAdapters`
  ADD CONSTRAINT `NetAdapterInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `PhysicalMemories`
--
ALTER TABLE `PhysicalMemories`
  ADD CONSTRAINT `PhysMemInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `Processors`
--
ALTER TABLE `Processors`
  ADD CONSTRAINT `ProcessorInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `VideoAdapters`
--
ALTER TABLE `VideoAdapters`
  ADD CONSTRAINT `VideoAdapterInComputer` FOREIGN KEY (`computer_id`) REFERENCES `Computers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
