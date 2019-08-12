from tkinter import *
import MySQLdb


def xuan_ke(Sno):
    win = Toplevel()
    win.title("选课")
    win.geometry('700x400')

    def search_xuke():
        print(Sno)
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset="utf8")
        cursor = db.cursor()
        sql = "SELECT * FROM  SC \
                WHERE Grade IS NULL AND Sno = '%s'" % (Sno)
        try:
            cursor.execute(sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                str1 = str(result[0]) + " "  + str(result[1]) + " " + str(result[2])+ "\n"
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()

    x = 4
    xx = 250
    yy = 10

    Label(win, text="查询结果").place(x=xx, y=yy + 40)
    text1 = Text(win, height=10, width=30)
    text1.place(x=xx + 20, y=yy + 70)

    Button(win, text="返回", command=win.destroy).place(x=xx, y=yy + 250)
    Button(win, text="开始查看", command=search_xuke).place(x=xx + 250, y=yy + 250)

    win.mainloop()

#xuan_ke("201215124")