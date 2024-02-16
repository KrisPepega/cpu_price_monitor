import pyodbc
from datetime import datetime

server = "YourServer"
database = "CpuDb"
username = "YourUsername"
password = "YourPassword"
driver = "{ODBC Driver 17 for SQL Server}"
con_string = f"DRIVER={driver};\
                    SERVER={server};\
                    DATABASE={database};\
                    UID={username};\
                    PWD={password}"


class DBHandler:

    def __init__(self) -> None:
        self._db = None

    def db_connect(self, connection_str: str):
        self._db = pyodbc.connect(connection_str)

    def get_cpu(self, id: int):
        sql = "SELECT * FROM Cpus WHERE Id = (?)"
        with self._db.cursor() as cursor:
            cursor.execute(sql, (id))
            return cursor.fetchval()

    def get_cpu_id(self, pr_id: int):
        sql = "SELECT Id FROM Cpus WHERE prId = (?)"
        with self._db.cursor() as cursor:
            cursor.execute(sql, (pr_id))
            return cursor.fetchval()

    def create_cpu(
        self,
        pr_id: int,
        name: str,
        description: str,
        brand: str,
        user_rating: float,
        total_ratings: int,
        img_path: str,
        lowest_price: float,
    ):
        sql = f"INSERT Cpus OUTPUT INSERTED.Id VALUES ( ?, ?, ?, ?, ?, ?, ?, ?)"
        data = (
            pr_id,
            name,
            description,
            brand,
            user_rating,
            total_ratings,
            img_path,
            int(lowest_price * 100),
        )

        with self._db.cursor() as cursor:
            cursor.execute(sql, data)
            record = cursor.fetchval()
            cursor.commit()

        return record

    def create_price(self, price: float, vendor_link: str, cpu_id: int):
        sql = "INSERT Prices VALUES ( ?, ?, ?, ?)"
        data = (int(price * 100), datetime.now(), cpu_id, vendor_link)
        with self._db.cursor() as cursor:
            cursor.execute(sql, data)
            cursor.commit()

    def update_cpu(
        self,
        id: int,
        pr_id: int,
        name: str,
        description: str,
        brand: str,
        user_rating: float,
        total_ratings: int,
        img_path: str,
        lowest_price: float,
    ):
        sql = "UPDATE Cpus SET prId = ?, Name = ?, Description = ?, Brand = ?, UserRating = ?, TotalRatings = ?, Img = ?, LowestPrice = ? WHERE Id = ?"
        data = (
            pr_id,
            name,
            description,
            brand,
            user_rating,
            total_ratings,
            img_path,
            int(lowest_price * 100),
            id,
        )
        with self._db.cursor() as cursor:
            cursor.execute(sql, data)
            cursor.commit()


db_handler = DBHandler()
db_handler.db_connect(con_string)
