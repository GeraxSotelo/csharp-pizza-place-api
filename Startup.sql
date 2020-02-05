USE csharppizzaplace;

CREATE TABLE pizzas (
id int NOT NULL AUTO_INCREMENT,
name VARCHAR(255) NOT NULL,
description VARCHAR(255),
price INT DEFAULT 0,
PRIMARY KEY (id)
);