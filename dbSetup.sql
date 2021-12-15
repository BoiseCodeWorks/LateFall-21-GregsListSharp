-- CREATE TABLE IF NOT EXISTS accounts(
--   id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
--   createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
--   updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
--   name varchar(255) COMMENT 'User Name',
--   email varchar(255) COMMENT 'User Email',
--   picture varchar(255) COMMENT 'User Picture'
-- ) default charset utf8 COMMENT '';
-- NOTE Instantiate the table
CREATE TABLE IF NOT EXISTS cars(
  id INT AUTO_INCREMENT NOT NULL primary key,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  make TEXT NOT NULL,
  model TEXT NOT NULL,
  year INT NOT NULL COMMENT 'Year the car was made',
  price INT NOT NULL,
  imgURL TEXT NOT NULL,
  description TEXT NOT NULL,
  color TEXT NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
);
DROP TABLE cars;
-- NOTE Alter the table after it's creation (ASK MARK)
-- ALTER TABLE cars(
-- );
-- NOTE create a car
INSERT INTO
  cars (
    make,
    model,
    year,
    price,
    imgURL,
    description,
    color
  )
VALUES
  (
    'Waine',
    'Watmobile',
    2020,
    500000,
    'https://www.sideshow.com/storage/product-images/908080/batmobile_dc-comics_silo.png',
    'broom im watman',
    "wlack with a tiny bit of wellow"
  );
-- NOTE create 2 cars
INSERT INTO
  cars (
    make,
    model,
    year,
    price,
    imgURL,
    description,
    color
  )
VALUES
  (
    'Wayne',
    'Batmobile',
    2021,
    5000000,
    'https://www.sideshow.com/storage/product-images/908080/batmobile_dc-comics_silo.png',
    'this is a test',
    "black with a tiny bit of yellow"
  ),
  (
    'Wayne Inc.',
    'Old scholl batmobile',
    1990,
    25,
    'https://m.media-amazon.com/images/I/71kwWbItL4L._AC_SL1500_.jpg',
    'test',
    "black with a tiny bit of yellow"
  );
-- NOTE Get make model of all cars
SELECT
  make,
  model
FROM
  cars;
--NOTE Get all cars
SELECT
  *
FROM
  cars;
-- REVIEW Get all cars, with Creator Populated
SELECT
  car.*,
  account.*
FROM
  cars car
  JOIN accounts account ON car.creatorId = account.id;
-- NOTE Get 1 car by id
SELECT
  *
FROM
  cars
WHERE
  id = 2;
-- NOTE Get all cars that have 'Wayne' in the make
SELECT
  *
FROM
  cars
WHERE
  make LIKE '%Wayne%';
-- NOTE Remove 1 car
DELETE FROM
  cars
WHERE
  id = 4;
-- NOTE Remove all cars with 'test' in the description
DELETE FROM
  cars
WHERE
  description LIKE '%test%';
-- NOTE Delete jsut these cars
DELETE FROM
  cars
WHERE
  id IN (27, 28, 29, 31);
-- NOTE Update 1 car
UPDATE
  cars
SET
  make = 'Wayne',
  model = 'Wombatmobile',
  year = 2021,
  price = 0,
  imgURL = 'https://static.wikia.nocookie.net/nintenshows/images/1/16/Snapshot20120407175201.jpg/revision/latest?cb=20120407155331',
  description = "Wombatman's Newley branded super fast but not as fast as batmans mobile",
  color = 'chocolate'
WHERE
  id = 32;