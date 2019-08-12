import MySQLdb
from tkinter import *

def test1():
    # 打开数据库连接
    db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")

    # 使用cursor()方法获取操作游标
    cursor = db.cursor()

    # SQL 插入语句
    sql = """INSERT INTO S(Sno,
             Sname, Ssex, Sage, Sdept)
             VALUES ('%s', '%s', '%s', '%s', '%s')""" % ('201215343','李应飞','男','34', 'cs')
    try:
        # 执行sql语句
        cursor.execute(sql)
        # 提交到数据库执行
        db.commit()
    except:
        # 如果发生错误则回滚
        db.rollback()

    # 关闭数据库连接
    db.close()

def f():
    db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
    # 使用cursor()方法获取操作游标
    cursor = db.cursor()

    # SQL 插入语句
    sql = """INSERT INTO SC(Sno,
             Cno, Grade)
             VALUES ('%s', '%s', '%s')""" % ("201215123", "1","90")
    try:
        # 执行sql语句
        cursor.execute(sql)
        # 提交到数据库执行
        db.commit()
    except:
        # 如果发生错误则回滚
        print("error")

    # 关闭数据库连接
    db.close()

def insert1():
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  S"

        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            for result in results:
                i = 1
                str1 = str(result[0])
                print(str1)
                while(i < len(result)):
                    str1 = str1 + " " + str(result[i])
                    i = i+1
                    print(str1)
                str1 = str1 + ' \n'
                print(str1)

        except:
            print("ERROR!")
        db.close()
def test_a():
    db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
    # 使用cursor()方法获取操作游标
    cursor = db.cursor()
    # SQL 插入语句 注意 占位符和双引号

    sql ="""DELETE FROM USER WHERE USERNAME = '%s'""" % ('xiaoming')
    try:
        # 执行sql语句
        cursor.execute(sql)
        # 提交到数据库执行
        db.commit()
    except:
        #db.rollback()
        print("error")

    # 关闭数据库连接
    db.close()

def test_cavs():
    root = Tk()
    # 背景
    canvas = Canvas(root, width=1200, height=699, bd=0, highlightthickness=0)

    img = PhotoImage(file="images/1.gif")
    canvas.create_image(700, 500, image=img)
    canvas.pack()
    entry = Entry(root, insertbackground='blue', highlightthickness=2)
    entry.pack()

    #canvas.create_window(100, 50, width=100, height=20,window=entry)

    root.mainloop()
#insert1()
#test1()
#test_cavs()
#f()
test_a()

#select Sno,Sname from S where Sno in( select Sno from SC where Grade = '76' ) 0.963055
#select Sno from SC where Grade = '76'  0.020001
#select Sno,Sname from S where Sno in(select Sno from( select Sno from SC where Grade = '76' ) as tb) 0.27002
