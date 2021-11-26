using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tutoria_S6_app
{
    public interface DataBase
    {
        SQLiteAsyncConnection GetConnection();

    }
}
