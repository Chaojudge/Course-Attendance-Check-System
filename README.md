# Course-Attendance-Check-System(C#版本)
系统介绍：
  课堂考勤服务端和学生签到计时服务端采用C/S开发模式，本实验对主要核心功能进行设计与实现，可用于高校课堂中的学生课堂得课堂考勤和管理，随着移动端科技的发展，尤其是移动交流通信和游戏方面，现在越来越多的学生出现上课玩手机的现象，所以根据现在各个高校的现状，该信息系统的作用有：学生基本签到、学生计时签到功能、课堂手动签到、奖惩处理以及下课结束功能。
  
1.系统能够实现教师自由设置连接数据库的配置、课堂时间配置、服务端配置以及内网WIFI配置以及相关配置的读取和检测。

2.系统采用CS模式，系统能够实现基本的学生手机客户端签到，同时系统的考勤模式分两种：一种为签到模式，一种为计时模式。

3.能够通过学生学号、手机号码、手机硬件地址来实现防止学生多次代签

4.能够通过CS模式实现手机客户端持续计时发送给PC电脑服务端以实现防止学生中途逃课以及切换网络玩手机，同时学生可以关闭屏幕而不影响计时、手机要求禁止使用Home、Menu和Back键来退出程序。

5.学生手机客户端持续计时的时间能够决定本次学生的课堂成绩，可以由以下公式获得：
本次课堂成绩=持续计时时间/（下课时间-启动服务端时间）X100

6.下课结束后考勤系统能够提供在教师指定路径中生成教师指定名称的考勤情况表格文件.xls和缺勤名单表格文件.xls的生成，其中考勤情况表格内容文件格式为：学号、班级、姓名、成绩，而确定名单表格内容文件格式为：学号、班级、姓名。

7.系统在考勤时，能够实现手动签到，以帮助没有携带手机的学生签到，能够实现奖惩处理，以帮助教师在课堂根据某个学生的表现来加减本次课堂成绩，能够实现随机点名，以帮助教师能够随机抽取学生起来回答问题等。

8.系统能够提供成绩表管理，可以实现将多次课堂成绩文件[或多次作业成绩文件]进行计算处理并导出到教师指定路径的教师指定名称的总课堂成绩文件[总作业成绩文件]。

9.系统能够提供课程成绩管理，能够实现将总课堂成绩、总作业成绩计算处理成平时成绩，同时再通过考试成绩以及教师指定的平时成绩合格限制来生成到教师指定路径的教师指定名称的课程成绩文件。

10.约束条件：该系统只开发核心功能，以便未来的系统提供好的技术方案，该系统是即时系统，数据库仅用来暂时储存和处理数据，没有触发器、存储过程以及外键等，不具有较好的安全性，学生名单、本次课堂成绩以及缺勤名单采用.csv，内容格式固定，成绩表管理功能暂时不做。

手机计时锁屏客户端：https://github.com/Chaojudge/CouseClient
