-- 가짜데이터 테이블
CREATE TABLE smarthome.fakedatas (
  sensing_dt DATETIME NOT NULL,
  pub_id VARCHAR(10) NOT NULL,
  count DECIMAL NOT NULL,
  temp DECIMAL(5,1) NOT NULL,
  humid DECIMAL(5,1) NOT NULL,
  light CHAR(1) NOT NULL,
  human CHAR(1) NOT NULL,
  PRIMARY KEY (sensing_dt, pub_id));

-- 실제데이터 테이블
CREATE TABLE sensingdatas (
  idx BIGINT NOT NULL AUTO_INCREMENT,
  sensing_dt DATETIME NOT NULL,
  light INT NOT NULL,
  rain INT NOT NULL,
  temp FLOAT NOT NULL,
  humid FLOAT NOT NULL,
  fan VARCHAR(3) NOT NULL,
  vul VARCHAR(3) NOT NULL,
  real_light VARCHAR(3) NOT NULL,
  chaim_bell VARCHAR(3) NOT NULL,
  PRIMARY KEY (idx));