import MySQLdb
import random

snos = []
for i in range(10000):
    Sno = str(random.randint(201215123,201396044))#学号
    Cno = str(random.randint(1, 7))#课程号
    Grade = str(random.randint(40, 100))#成绩

    if (Sno, Cno) not in snos:#学号和课程号仅出现一次
        snos.append((Sno, Cno))
        # 打开数据库连接
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        # 使用cursor()方法获取操作游标
        cursor = db.cursor()

        # SQL 插入语句
        sql = """INSERT INTO SC(Sno,
                 Cno, Grade)
                 VALUES ('%s', '%s', '%s')""" % (str(Sno), str(Cno), str(Grade))
        try:
            # 执行sql语句
            cursor.execute(sql)
            # 提交到数据库执行
            db.commit()
            print(i)
        except:
            # 如果发生错误则回滚
            print("error")

        # 关闭数据库连接
        db.close()


