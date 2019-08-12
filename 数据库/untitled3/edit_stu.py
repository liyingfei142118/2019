from tkinter import *
import  MySQLdb

def edit_stu():
    win = Toplevel()
    win.title("修改学生信息")
    win.geometry('700x400')

    def insert_stu():
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

            Label(win1, text="修改成功").place(x = 130, y = 50)
            win1.mainloop()
        except:
            print("error")
            win1 = Toplevel()
            win1.title("提示消息")
            win1.geometry("400x200")

            Label(win1, text="修改失败").place(x = 130, y = 50)
            win1.mainloop()

        db.close()


    x=4
    xx = 250
    yy = 10
    Label(win, text="学号").place(x=xx, y=yy)
    Label(win, text="姓名").place(x=xx, y=yy+40)
    Label(win, text="性别").place(x=xx, y=yy+80)
    Label(win, text="年龄").place(x=xx, y=yy+120)
    Label(win, text="系").place(x=xx, y=yy+160)

    sno = Variable()
    Entry(win, textvariable=sno).place(x=xx+40, y=yy)
    sname = Variable()
    Entry(win, textvariable=sname).place(x=xx+40, y=yy+40)
    sex = Variable()
    Entry(win, textvariable=sex).place(x=xx+40, y=yy+80)
    sage = Variable()
    Entry(win, textvariable=sage).place(x=xx+40, y=yy+120)
    sdept = Variable()
    Entry(win, textvariable=sdept).place(x=xx+40, y=yy+160)

    Button(win, text="修改", command=insert_stu).place(x=xx, y=yy+200)
    Button(win, text="返回", command=win.destroy).place(x=xx+120, y=yy+200)


    win.mainloop()

#edit_stu()