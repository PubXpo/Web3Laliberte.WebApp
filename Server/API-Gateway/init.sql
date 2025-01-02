-- Create the database as the root user
CREATE DATABASE IF NOT EXISTS Web3LApp_db;

-- Create the admin user and grant privileges as the root user
CREATE USER IF NOT EXISTS 'admin'@'%' IDENTIFIED BY 'admin';
GRANT ALL PRIVILEGES ON Web3LApp_db.* TO 'admin'@'%';
FLUSH PRIVILEGES;

-- Switch to using the admin user
USE Web3LApp_db;
