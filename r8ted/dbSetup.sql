CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key ,
  createdAt TIMESTAMP,
  updatedAt TIMESTAMP,
  name varchar(255),
  email varchar(255),
  picture varchar(255)
);
