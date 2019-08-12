from tkinter import *
import  MySQLdb
import height_search

def select_course():
    win = Toplevel()
    win.title("学生选课管理")
    win.geometry('1200x700')

    def insert_date():
        Sno = sno.get()
        Cno = cno.get()
        Grade = grade.get()


        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()

        sql = """INSERT INTO SC(Sno,
                 Cno, Grade)
                 VALUES ('%s', '%s', '%s')""" % (Sno, Cno, Grade)
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
        Sno = sno.get()
       # print(Sno)
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SC \
                WHERE Sno = '%s'" % (Sno)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " "  + str(result[1]) + " "  + str(result[2])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()

    def search2():
        Cno = cno.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SC \
                WHERE Cno = '%s'" % (Cno)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " "  + str(result[1]) + " "  + str(result[2])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()

    def search3():
        Grade = grade.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SC \
                WHERE Grade = '%s'" % (Grade)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " "  + str(result[1]) + " "  + str(result[2])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()

    def del_date():
        Sno = sno.get()
        Cno = cno.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
        cursor = db.cursor()
        sql = """DELETE FROM SC WHERE Sno = '%s' and Cno = '%s'""" % (Sno, Cno)
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


    def update_date():
        Sno = sno.get()
        Cno = cno.get()
        Grade = grade.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku")
        cursor = db.cursor()
        sql = "UPDATE SC SET Grade = '%s' WHERE Sno = '%s' and Cno = '%s'" % (Grade, Sno, Cno)
        try:
            cursor.execute(sql)
            db.commit()
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="更新成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            db.rollback()
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="更新失败").place(x = 130, y = 50)
            win1.mainloop()
        db.close()



    Label(win, text="学号").grid(row=0, column=1)
    Label(win, text="课程号").grid(row=0, column=3)
    Label(win, text="成绩").grid(row=0, column=5)

    sno = Variable()
    Entry(win, textvariable=sno).grid(row=0, column=2)
    cno = Variable()
    Entry(win, textvariable=cno).grid(row=0, column=4)
    grade = Variable()
    Entry(win, textvariable=grade).grid(row=0, column=6)

    Button(win, text="添加", command=insert_date).grid(row=0, column=11)

    Button(win, text="查询", command=search1).grid(row=1, column=2)
    Button(win, text="查询", command=search2).grid(row=1, column=4)
    Button(win, text="查询", command=search3).grid(row=1, column=6)

    Button(win, text="删除（学号+课程）", command=del_date).grid(row=2, column=2)
    Button(win, text="更新成绩", command=update_date).grid(row=3, column=2)



    Label(win, text="查询结果").place(x=220, y=150)
    text1 = Text(win, height=30, width=60)
    text1.place(x=300,y=150)

    Button(win, text="高级查询", command=height_search.height_search).place(x=1000,y=200)
    Button(win, text="返回", command=win.destroy).place(x=1000, y=240)

    win.mainloop()

#select_course()