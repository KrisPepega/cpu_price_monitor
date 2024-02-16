SQL Server setup:
1. Enable both Windows & SQL Server Authentication for SQL Server
2. You will need to create a login & user for the database which will be used in the db_handler.py.

Installing python requirements:
1. cd to data_yoinker
2. pip install -r requirements.txt

Update server, username & password to correlate with values from SQL Server setup in data_yoinker/src/db_handler.py

How to run:
1. Create "CpuDb"
2. Run migrations
3. Run data_yoinker/src/fetch_data.py
4. Run the cpu_price_monitor project.
