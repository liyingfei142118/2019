import MySQLdb

def creat_user():
    # 打开数据库连接
    db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
    # 使用cursor()方法获取操作游标
    cursor = db.cursor()

    # 如果数据表已经存在使用 execute() 方法删除表。
    cursor.execute("DROP TABLE IF EXISTS CH1")

    # 创建数据表SQL语句
    sql = """CREATE TABLE USER(
             USERNAME  CHAR(20) NOT NULL,
             PASSWORD CHAR(20) NOT NULL
             )"""

    cursor.execute(sql)

    # 关闭数据库连接
    db.close()

def creat_SX():
    # 打开数据库连接
    db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
    # 使用cursor()方法获取操作游标
    cursor = db.cursor()

    # 如果数据表已经存在使用 execute() 方法删除表。
    cursor.execute("DROP TABLE IF EXISTS CH1")
#      PRIMARY KEY(Cno）,FOREIGN KEY (Cname) REFERENCES C(Cname)
    # 创建数据表SQL语句
    sql = """CREATE TABLE SX(
             Cno  CHAR(4) NOT NULL,
             Cname CHAR(40) NOT NULL,      
             FOREIGN KEY (Cno) REFERENCES C(Cno)
             )"""

    cursor.execute(sql)

    # 关闭数据库连接
    db.close()

creat_SX()