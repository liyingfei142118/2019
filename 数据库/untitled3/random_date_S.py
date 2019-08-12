import MySQLdb
import random

#snos = []
#要生成一百万条数据依据学号产生（201215121-202215121）
#批量插入失败，改一条一条的插入
#插入比较慢，只插入到201411747
for i in range(201411748,202215201):
    Sname = "小李"+ str(i)
    Ssex = random.choice(['男', '女'])
    Sage = str(random.randint(16, 20))
    Sdept = random.choice(['cs', 'ma', 'IS'])
   # snos.append((str(i), Sname, Ssex, Sage, Sdept))

    # 打开数据库连接
    db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
    # 使用cursor()方法获取操作游标
    cursor = db.cursor()
    print(str(i), str(Sname), str(Ssex), str(Sage), str(Sdept))
    # SQL 插入语句
    sql = """INSERT INTO S(Sno,
             Sname, Ssex, Sage, Sdept)
             VALUES ('%s', '%s', '%s', '%s', '%s')""" % (str(i), str(Sname), str(Ssex), str(Sage), str(Sdept))
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

