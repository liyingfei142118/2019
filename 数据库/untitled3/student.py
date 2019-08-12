from tkinter import *
import  MySQLdb
import  height_search

def student():
    win = Toplevel()
    win.title("学生信息管理")
    win.geometry('1200x700')

    def insert1():
        Sno = sno.get()
        Sname = sname.get()
        Sex = sex.get()
        Sage = sage.get()
        Sdept = sdept.get()

        strt = Sno + Sname + Sex +Sage +Sdept
        print(strt)
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()

        sql = """INSERT INTO S(Sno,
                 Sname, Ssex, Sage, Sdept)
                 VALUES ('%s', '%s', '%s', '%s', '%s')""" % (Sno, Sname, Sex, Sage, Sdept)
        try:
            cursor.execute(sql)
            db.commit()

            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="插入成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="插入失败").place(x = 130, y = 50)
            win1.mainloop()
            print("error")

        db.close()

    def search1():
        Sno = sno.get()
       # print(Sno)
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  S \
                WHERE Sno = '%s'" % (Sno)
        try:
            cursor.execute(sql)
            results = cursor.fetchone()
            text1.delete('1.0', END)
            str1 = str(results[0]) + " " + str(results[1]) + " " + str(results[2])+ " " + str(results[3]) + " " + str(results[4])
            text1.insert(INSERT, str1)

        except:
            print("ERROR!")
        db.close()

    def search2():
        Sname = sname.get()
        #print(Sname)
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  S \
                 WHERE Sname = '%s'" % (Sname)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0',END)
            for result in results:
                str1 = str(result[0]) + " " + str(result[1]) + " " + str(result[2])+ " " + str(result[3])+ " " + str(result[4])
                text1.insert(INSERT, str1)+ "\n"


        except:
            print("ERROR!")
        db.close()

    def search3():
        Sex = sex.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()

        if(Sex == "男"):
            sql = "SELECT * FROM  S \
                    WHERE Ssex = '男'"
        elif(Sex == "女"):
            sql = "SELECT * FROM  S \
                    WHERE Ssex = '女'"

        try:
            cursor.execute(sql)
            # 获取所有记录列表
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " " + str(result[1]) + " " + str(result[2]) + " " + str(result[3]) + " " + str(
                    result[4]) + "\n"
                text1.insert(INSERT, str1)
        except:
            db.rollback()
        db.close()

    def search4():
        Sage = sage.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  S \
                WHERE Sage = '%s'" % (Sage)
        try:
            cursor.execute(sql)
            # 获取所有记录列表
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " " + str(result[1]) + " " + str(result[2]) + " " + str(result[3]) + " " + str(
                    result[4])+ "\n"
                text1.insert(INSERT, str1)
        except:
            db.rollback()
        db.close()

    def search5():
        Sdept1 = sdept.get()
        print(Sdept1)
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()

        sql = "SELECT * FROM  S \
                WHERE Sdept ='%s'" % (Sdept1)
        try:
            cursor.execute(sql)
            # 获取所有记录列表
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " " + str(result[1]) + " " + str(result[2]) + " " + str(result[3]) + " " + str(
                    result[4])+ "\n"
                text1.insert(INSERT, str1)

        except:
            db.rollback()
        db.close()
    def del_date():
        Sno = sno.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
        cursor = db.cursor()
        sql = """DELETE FROM S WHERE Sno = '%s'""" % (Sno)
        try:
            cursor.execute(sql)
            db.commit()

            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="删除成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            db.rollback()

            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="删除成功").place(x = 130, y = 50)
            win1.mainloop()
        db.close()


    def update_date():
        Sno = sno.get()
        Sname = sname.get()
        Sex = sex.get()
        Sage = sage.get()
        Sdept = sdept.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
        cursor = db.cursor()
        sql = """DELETE FROM S WHERE Sno = '%s'""" % (Sno)
        try:
            cursor.execute(sql)
            db.commit()
        except:
            print("error")
        db.close()

        print("%%%")
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()

        sql = """INSERT INTO S(Sno,
                 Sname, Ssex, Sage, Sdept)
                 VALUES ('%s', '%s', '%s', '%s', '%s')""" % (Sno, Sname, Sex, Sage, Sdept)
        try:
            cursor.execute(sql)
            db.commit()
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="更新成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            print("error")
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="更新失败").place(x = 130, y = 50)
            win1.mainloop()
        db.close()

    Label(win, text="学号").grid(row=0, column=1)
    Label(win, text="姓名").grid(row=0, column=3)
    Label(win, text="性别").grid(row=0, column=5)
    Label(win, text="年龄").grid(row=0, column=7)
    Label(win, text="系").grid(row=0, column=9)

    sno = Variable()
    Entry(win, textvariable=sno).grid(row=0, column=2)
    sname = Variable()
    Entry(win, textvariable=sname).grid(row=0, column=4)
    sex = Variable()
    Entry(win, textvariable=sex).grid(row=0, column=6)
    sage = Variable()
    Entry(win, textvariable=sage).grid(row=0, column=8)
    sdept = Variable()
    Entry(win, textvariable=sdept).grid(row=0, column=10)

    Button(win, text="添加", command=insert1).grid(row=0, column=11)


    Button(win, text="查询", command=search1).grid(row=1, column=2)
    Button(win, text="查询", command=search2).grid(row=1, column=4)
    Button(win, text="查询", command=search3).grid(row=1, column=6)
    Button(win, text="查询", command=search4).grid(row=1, column=8)
    Button(win, text="查询", command=search5).grid(row=1, column=10)

    Button(win, text="删除", command=del_date).grid(row=2, column=2)
    Button(win, text="更新", command=update_date).grid(row=3, column=2)

    Label(win, text="查询结果").place(x=220, y=150)
    text1 = Text(win, height=30, width=60)
    text1.place(x=300, y=150)

    Button(win, text="高级查询", command=height_search.height_search).place(x=1000,y=200)
    Button(win, text="返回", command=win.destroy).place(x=1000, y=240)
    win.mainloop()

#student()