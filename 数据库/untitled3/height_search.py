from tkinter import *
import  tkinter.messagebox
import  MySQLdb
import datetime
def height_search():
    win = Toplevel()
    win.title("高级查询")
    win.geometry('1200x700')

    def search():
        Sql = sql.get()
        print(Sql)
        start = datetime.datetime.now()         #开始时间
        db = MySQLdb.connect("localhost", "root", "142118", "shujuku", charset = "utf8")
        cursor = db.cursor()
        try:
            cursor.execute(Sql)
            results = cursor.fetchall()
            text1.delete('1.0', END)
            for result in results:
                i = 1
                str1 = str(result[0])
                while(i < len(result)):
                    str1 = str1 + " " + str(result[i])
                    i = i+1
                str1 = str1 + ' \n'
                text1.insert(INSERT, str1)
        except:
            print("ERROR!")
        db.close()
        end = datetime.datetime.now()       #结束时间

        t = end - start                     #总的时间
        tkinter.messagebox.showinfo('运行时间',t)
        win.mainloop()



    Label(win, text="输入条件").place(x=220, y=80)
    sql = Variable()
    Entry(win, textvariable=sql, width=60).place(x=300, y=80)

    Label(win, text="查询结果").place(x=220, y=150)
    text1 = Text(win, height=25, width=60)
    text1.place(x=300, y=150)

    Button(win, text="开始查询", command=search).place(x=1000,y=200)
    Button(win, text="返回", command=win.destroy).place(x=1000, y=240)
    win.mainloop()

#height_search()