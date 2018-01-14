/*
Navicat MariaDB Data Transfer

Source Server         : localhost_3306
Source Server Version : 100302
Source Host           : localhost:3306
Source Database       : topicdb

Target Server Type    : MariaDB
Target Server Version : 100302
File Encoding         : 65001

Date: 2017-12-23 16:49:23
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_admin
-- ----------------------------
DROP TABLE IF EXISTS `t_admin`;
CREATE TABLE `t_admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(32) NOT NULL COMMENT '登录名',
  `pwd` varchar(70) NOT NULL DEFAULT '' COMMENT 'bcrypt加密字符',
  `user_stat` int(1) NOT NULL DEFAULT 0 COMMENT '角色状态,默认0,1为已注销',
  PRIMARY KEY (`id`,`user_name`),
  UNIQUE KEY `user_name` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='教务管理员信息表';

-- ----------------------------
-- Records of t_admin
-- ----------------------------
INSERT INTO `t_admin` VALUES ('1', 'admin', '$2a$10$ipxxR74SUQ12qsx6p8VjGuLmKZWo/cLbrgPhr9J9uPYAxahRlEbKW', '0');

-- ----------------------------
-- Table structure for t_class
-- ----------------------------
DROP TABLE IF EXISTS `t_class`;
CREATE TABLE `t_class` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `class_id` varchar(40) NOT NULL COMMENT '班级UUID',
  `class_name` varchar(61) NOT NULL COMMENT '班级名称',
  `class_major_id` varchar(40) NOT NULL COMMENT '班级所属专业UUID',
  `class_note` varchar(255) DEFAULT NULL COMMENT '备注信息',
  `class_stat` int(1) NOT NULL DEFAULT 0 COMMENT '班级状态，默认0，1为已注销',
  PRIMARY KEY (`id`,`class_id`),
  UNIQUE KEY `class_id` (`class_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='班级信息表';

-- ----------------------------
-- Records of t_class
-- ----------------------------

-- ----------------------------
-- Table structure for t_dept
-- ----------------------------
DROP TABLE IF EXISTS `t_dept`;
CREATE TABLE `t_dept` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `dept_id` varchar(40) NOT NULL COMMENT '系别ID,UUID',
  `dept_name` varchar(64) NOT NULL COMMENT '系别名称',
  `dept_note` varchar(255) DEFAULT NULL COMMENT '备注信息',
  `dept_stat` int(1) NOT NULL DEFAULT 0 COMMENT '状态,默认0，1为已注销',
  PRIMARY KEY (`id`,`dept_id`,`dept_name`),
  UNIQUE KEY `dept_id` (`dept_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='系别信息表';

-- ----------------------------
-- Records of t_dept
-- ----------------------------

-- ----------------------------
-- Table structure for t_log
-- ----------------------------
DROP TABLE IF EXISTS `t_log`;
CREATE TABLE `t_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(32) NOT NULL COMMENT '登录名',
  `log_ip` varchar(15) NOT NULL,
  `log_info` varchar(255) NOT NULL COMMENT '日志内容',
  `log_date` datetime NOT NULL DEFAULT current_timestamp() COMMENT '日志记录时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='日志信息表';

-- ----------------------------
-- Records of t_log
-- ----------------------------

-- ----------------------------
-- Table structure for t_major
-- ----------------------------
DROP TABLE IF EXISTS `t_major`;
CREATE TABLE `t_major` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `major_id` varchar(40) NOT NULL COMMENT '专业ID,UUID',
  `major_name` varchar(64) NOT NULL COMMENT '名称',
  `major_dept_id` varchar(40) NOT NULL COMMENT '系别ID,UUID',
  `major_stat` int(1) NOT NULL DEFAULT 0 COMMENT '状态，默认0，1为已注销',
  `major_note` varchar(255) DEFAULT NULL COMMENT '备注信息',
  PRIMARY KEY (`id`,`major_id`),
  UNIQUE KEY `major_id` (`major_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='专业信息表';

-- ----------------------------
-- Records of t_major
-- ----------------------------

-- ----------------------------
-- Table structure for t_notice
-- ----------------------------
DROP TABLE IF EXISTS `t_notice`;
CREATE TABLE `t_notice` (
  `id` int(11) NOT NULL AUTO_INCREMENT COMMENT '公告id',
  `notice_type` int(1) NOT NULL DEFAULT 0 COMMENT '公告类型，0出题公告，1选题公告,2其他公告',
  `notice_title` varchar(64) NOT NULL COMMENT '公告标题',
  `notice_body` text DEFAULT NULL COMMENT '公告正文',
  `notice_user_name` varchar(32) NOT NULL COMMENT '发布者登录名',
  `notice_date` datetime NOT NULL DEFAULT current_timestamp() COMMENT '发布日期',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='公告信息表';

-- ----------------------------
-- Records of t_notice
-- ----------------------------

-- ----------------------------
-- Table structure for t_select
-- ----------------------------
DROP TABLE IF EXISTS `t_select`;
CREATE TABLE `t_select` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `select_id` varchar(40) NOT NULL COMMENT '选题编号，采用系统生成的UUID',
  `select_student_xh` varchar(20) NOT NULL COMMENT '学生ID,UUID',
  `select_topic_id` varchar(40) NOT NULL COMMENT '出题ID,UUID',
  `select_stat` int(1) NOT NULL DEFAULT 0 COMMENT '通过select_stat字段标注选题结果状态：0为等待导师审核,1为审核通过,2为一审不通过,3为二审不通过等待分配,9为已发布结果',
  PRIMARY KEY (`id`,`select_id`,`select_student_xh`),
  UNIQUE KEY `select_id` (`select_id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='选题信息表';

-- ----------------------------
-- Records of t_select
-- ----------------------------

-- ----------------------------
-- Table structure for t_student
-- ----------------------------
DROP TABLE IF EXISTS `t_student`;
CREATE TABLE `t_student` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `student_xh` varchar(20) NOT NULL COMMENT '学号',
  `student_name` varchar(10) NOT NULL COMMENT '姓名',
  `student_class_id` varchar(40) NOT NULL COMMENT '所属班级UUID',
  `student_pwd` varchar(60) NOT NULL COMMENT '密码',
  `student_pwd_q` varchar(64) DEFAULT NULL COMMENT '密保问题',
  `student_pwd_a` varchar(64) DEFAULT NULL COMMENT '密保答案',
  `student_stat` int(11) NOT NULL DEFAULT 0 COMMENT '状态，默认0，1为已注销',
  `student_note` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`,`student_xh`),
  UNIQUE KEY `student_id` (`student_xh`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='学生信息表';

-- ----------------------------
-- Records of t_student
-- ----------------------------

-- ----------------------------
-- Table structure for t_teacher
-- ----------------------------
DROP TABLE IF EXISTS `t_teacher`;
CREATE TABLE `t_teacher` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `teacher_gh` varchar(20) NOT NULL COMMENT '导师工号',
  `teacher_name` varchar(10) NOT NULL COMMENT '姓名',
  `teacher_dept_id` varchar(40) NOT NULL COMMENT '所属系别UUID',
  `teacher_major_id` varchar(40) DEFAULT NULL COMMENT '教研室主任专业UUID',
  `teacher_pwd` varchar(60) NOT NULL COMMENT '密码',
  `teacher_pwd_q` varchar(64) DEFAULT NULL COMMENT '密保问题',
  `teacher_pwd_a` varchar(64) DEFAULT NULL COMMENT '密保答案',
  `teacher_stat` int(1) NOT NULL DEFAULT 0 COMMENT '状态：默认0，1为已注销',
  `teacher_note` varchar(255) DEFAULT NULL COMMENT '备注信息',
  `teacher_type` int(1) NOT NULL DEFAULT 0 COMMENT '导师类型,0为导师，1为教研室主任',
  PRIMARY KEY (`id`,`teacher_gh`),
  UNIQUE KEY `teacher_id` (`teacher_gh`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='导师/教研室主任信息表';

-- ----------------------------
-- Records of t_teacher
-- ----------------------------

-- ----------------------------
-- Table structure for t_topic
-- ----------------------------
DROP TABLE IF EXISTS `t_topic`;
CREATE TABLE `t_topic` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `topic_id` varchar(40) NOT NULL COMMENT '出题ID,UUID',
  `topic_teacher_gh` varchar(20) NOT NULL COMMENT '出题教师ID,UUID',
  `topic_class_id` varchar(40) NOT NULL COMMENT '可选班级ID,UUID',
  `topic_name` varchar(64) NOT NULL COMMENT '论文题目',
  `topic_note` varchar(255) DEFAULT NULL COMMENT '备注信息，可以填写审核意见',
  `topic_stat` int(1) NOT NULL DEFAULT 0 COMMENT '为论文出题状态：0为待审核，1为审核不通过,5为已注销,9为审核通过',
  `topic_num` int(3) NOT NULL DEFAULT 0 COMMENT '论文可选题人数',
  PRIMARY KEY (`id`,`topic_id`),
  UNIQUE KEY `topic_id` (`topic_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='论文出题信息表';

-- ----------------------------
-- Records of t_topic
-- ----------------------------

-- ----------------------------
-- View structure for v_class
-- ----------------------------
DROP VIEW IF EXISTS `v_class`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `v_class` AS SELECT
t_class.id,
t_class.class_id,
t_class.class_name,
t_class.class_major_id,
t_class.class_note,
t_class.class_stat,
t_dept.dept_name,
t_major.major_name,
t_dept.dept_id
FROM
t_class ,
t_dept ,
t_major
WHERE
t_class.class_major_id = t_major.major_id AND
t_major.major_dept_id = t_dept.dept_id ;

-- ----------------------------
-- View structure for v_major
-- ----------------------------
DROP VIEW IF EXISTS `v_major`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_major` AS SELECT
t_major.id,
t_major.major_id,
t_major.major_name,
t_major.major_dept_id,
t_major.major_stat,
t_major.major_note,
t_dept.dept_name
FROM
t_major ,
t_dept
WHERE
t_major.major_dept_id = t_dept.dept_id ;


-- ----------------------------
-- View structure for v_student
-- ----------------------------
DROP VIEW IF EXISTS `v_student`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_student` AS SELECT
t_student.id,
t_student.student_xh,
t_student.student_name,
t_student.student_class_id,
t_student.student_stat,
t_student.student_note,
v_class.class_id,
v_class.class_name,
v_class.class_major_id,
v_class.class_note,
v_class.class_stat,
v_class.dept_name,
v_class.major_name,
v_class.dept_id
FROM
t_student ,
v_class
WHERE
t_student.student_class_id = v_class.class_id ;

-- ----------------------------
-- View structure for v_teacher
-- ----------------------------
DROP VIEW IF EXISTS `v_teacher`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_teacher` AS SELECT
t_teacher.id,
t_teacher.teacher_gh,
t_teacher.teacher_name,
t_teacher.teacher_dept_id,
t_teacher.teacher_major_id,
t_teacher.teacher_stat,
t_teacher.teacher_note,
t_teacher.teacher_type,
t_dept.dept_name
FROM
t_teacher ,
t_dept
WHERE
t_teacher.teacher_dept_id = t_dept.dept_id ;

-- ----------------------------
-- View structure for v_topic
-- ----------------------------
DROP VIEW IF EXISTS `v_topic`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_topic` AS SELECT
t_topic.id,
t_topic.topic_id,
t_topic.topic_teacher_gh,
t_topic.topic_class_id,
t_topic.topic_name,
t_topic.topic_note,
t_topic.topic_stat,
t_topic.topic_num,
v_teacher.teacher_name,
v_teacher.dept_name,
t_class.class_name,
(SELECT COUNT(t_select.select_topic_id) FROM t_select,t_topic WHERE t_select.select_topic_id = t_topic.topic_id GROUP BY t_select.select_topic_id ) AS select_sum,
v_teacher.teacher_dept_id
FROM
t_topic ,
v_teacher ,
t_class
WHERE
t_topic.topic_teacher_gh = v_teacher.teacher_gh AND
t_topic.topic_class_id = t_class.class_id ;


-- ----------------------------
-- View structure for v_select
-- ----------------------------
DROP VIEW IF EXISTS `v_select`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_select` AS SELECT
v_student.student_name,
v_student.class_id,
v_student.class_name,
v_student.class_major_id,
v_student.dept_name,
v_student.major_name,
v_student.dept_id,
t_select.id,
t_select.select_id,
t_select.select_student_xh,
t_select.select_topic_id,
t_select.select_stat,
v_topic.topic_teacher_gh,
v_topic.teacher_name,
v_topic.topic_num,
v_topic.topic_name
FROM
v_student ,
t_select ,
v_topic
WHERE
v_student.student_xh = t_select.select_student_xh AND
t_select.select_topic_id = v_topic.topic_id ;