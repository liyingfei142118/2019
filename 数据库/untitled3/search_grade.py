from tkinter import *
import  MySQLdb

def search_grade(Sno):

    win = Toplevel()
    win.title("查询课程成绩")
    win.geometry('700x400')

    def search_stu():
        Cno = cno.get()
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SC \
                WHERE Cno = '%s' AND Sno ='%s'" % (Cno, Sno)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " " + str(result[1]) + " "  + str(result[2])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()
    def search_stuall():
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SC \
                WHERE Sno ='%s'" % (Sno)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " " + str(result[1]) + " "  + str(result[2])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()

    x=4
    xx = 250
    yy = 10
    Label(win, text="课程号").place(x=xx, y=yy)

    cno = Variable()
    Entry(win, textvariable=cno).place(x=xx+70, y=yy)

    Label(win, text="查询结果").place(x=xx, y=yy+40)
    text1 = Text(win, height=10, width=20)
    text1.place(x=xx+70,y=yy+70)

    Button(win, text="查询", command=search_stu).place(x=xx+250, y=yy+30)
    Button(win, text="全部查询", command=search_stuall).place(x=xx + 300, y=yy + 30)
    Button(win, text="返回", command=win.destroy).place(x=xx, y=yy+250)


    win.mainloop()

#search_grade("201215121")