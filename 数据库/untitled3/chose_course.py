from tkinter import *
import  MySQLdb
import height_search

def chose_course():
    win = Toplevel()
    win.title("可选课程")
    win.geometry('1200x700')

    def insert_date():
        Cno = cno.get()
        Cname = cname.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()

        sql = """INSERT INTO SX(Cno,
                  Cname)
                  VALUES ('%s', '%s')""" % (Cno, Cname)
        try:
            cursor.execute(sql)
            db.commit()
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="插入成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            print("error")
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="插入失败").place(x = 130, y = 50)
            win1.mainloop()

        db.close()

    def search1():
        Cno = cno.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SX \
                 WHERE Cno = '%s'" % (Cno)
        try:
            cursor.execute(sql)
            results = cursor.fetchone()
            text1.delete('1.0', END)
            str1 = str(results[0]) + " "  + str(results[1])+ "\n"
            text1.insert(INSERT, str1)

        except:
            print("ERROR!")
        db.close()

    def search2():
        Cname = cname.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SX \
                 WHERE Cname = '%s'" % (Cname)
        try:
            cursor.execute(sql)
            # 获取所有记录列表
            results = cursor.fetchone()
            text1.delete('1.0', END)
            str1 = str(results[0]) + " "  + str(results[1])+ "\n"
            text1.insert(INSERT, str1)
        except:
            db.rollback()
        db.close()

    def del_date():
        Cno = cno.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
        cursor = db.cursor()
        sql = """DELETE FROM SX WHERE Cno = '%s'""" % (Cno)
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

            Label(win1, text="删除失败").place(x = 130, y = 50)
            win1.mainloop()
        db.close()

    Label(win, text="课程号").grid(row=0, column=1)
    Label(win, text="课程名").grid(row=0, column=3)

    cno = Variable()
    Entry(win, textvariable=cno).grid(row=0, column=2)
    cname = Variable()
    Entry(win, textvariable=cname).grid(row=0, column=4)

    Button(win, text="添加", command=insert_date).grid(row=0, column=11)

    Button(win, text="查询", command=search1).grid(row=1, column=2)
    Button(win, text="查询", command=search2).grid(row=1, column=4)

    Button(win, text="删除", command=del_date).grid(row=2, column=2)

    Label(win, text="查询结果").place(x=220, y=150)
    text1 = Text(win, height=30, width=60)
    text1.place(x=300,y=150)

    Button(win, text="高级查询", command=height_search.height_search).place(x=1000,y=200)
    Button(win, text="返回", command=win.destroy).place(x=1000, y=240)

    win.mainloop()

#chose_course()