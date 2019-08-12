from tkinter import *
import  MySQLdb

def xuan_ke(Sno):
    win = Toplevel()
    win.title("选课")
    win.geometry('700x400')

    def search_xuke():
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SX "
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " "  + str(result[1])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()

    def xuke():
        Cno = cno.get()

        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()

        sql = """INSERT INTO SC(Sno,
                 Cno, Grade)
                 VALUES ('%s', '%s', %s)""" % (Sno, Cno, "NULL")
        try:
            cursor.execute(sql)
            db.commit()
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="选课成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            print("error")
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="选课失败").place(x = 130, y = 50)
            win1.mainloop()

        db.close()

    x=4
    xx = 250
    yy = 10
    Label(win, text="课程号").place(x=xx, y=yy)

    cno = Variable()
    Entry(win, textvariable=cno).place(x=xx+70, y=yy)

    Label(win, text="查询结果").place(x=xx, y=yy+40)
    text1 = Text(win, height=10, width=30)
    text1.place(x=xx+20,y=yy+70)

    Button(win, text="选择", command=xuke).place(x=xx+250, y=yy+30)
    Button(win, text="返回", command=win.destroy).place(x=xx, y=yy+250)
    Button(win, text="查看可选课程", command=search_xuke).place(x=xx+200, y=yy + 250)

    win.mainloop()

#xuan_ke("201215124")