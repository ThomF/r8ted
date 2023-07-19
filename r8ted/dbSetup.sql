CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key ,
  createdAt TIMESTAMP,
  updatedAt TIMESTAMP,
  name varchar(255),
  email varchar(255),
  picture varchar(255)
);

CREATE TABLE IF NOT EXISTS review(
  id INT NOT NULL PRIMARY KEY,
  user_id VARCHAR(255) NOT NULL,
  title VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  movie_id INT NOT NULL,
  isPrivate BOOLEAN NOT NULL default false,
  FOREIGN KEY (user_id) REFERENCES accounts(id) ON DELETE CASCADE
);