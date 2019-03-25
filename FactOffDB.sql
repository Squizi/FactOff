CREATE DATABASE  FactOffDB;

USE FactOffDB;

CREATE TABLE users (
	id INT PRIMARY KEY,
	name VARCHAR(40),
	email VARCHAR(346),
	password NVARCHAR,
	profile_picture IMAGE
);

CREATE TABLE themes (
	id INT PRIMARY KEY,	
	name VARCHAR(40)
);

CREATE TABLE facts (
	id INT PRIMARY KEY,
	context NTEXT,
	rating FLOAT
);

CREATE TABLE tags (
	id INT PRIMARY KEY,
	name VARCHAR(40)
);

CREATE TABLE user_preferences (
	themeid INT,
	userid INT
	FOREIGN KEY (themeid) REFERENCES themes(id),
	FOREIGN KEY (userid) REFERENCES users(id) 
);

CREATE TABLE user_saved (
	userid INT,
	factid INT,
	FOREIGN KEY (userid) REFERENCES users(id),
	FOREIGN KEY (factid) REFERENCES facts(id)
);

CREATE TABLE fact_tags (
	tagid INT,
	factid INT,
	FOREIGN KEY (factid) REFERENCES facts(id),
	FOREIGN KEY (tagid) REFERENCES tags(id)
);