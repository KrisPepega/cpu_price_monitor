import requests
from types import SimpleNamespace
from db_handler import db_handler

DEBUG = False

page_size = 100
uri = f"https://www.pricerunner.dk/public/search/category/products/v3/DK/40?size={page_size}"

response = SimpleNamespace(**requests.get(uri).json())

pages = response.totalHits / page_size
print(pages)
cnt = 1

if __name__ == "__main__":
    while pages > 0:
        for i in response.products:
            i = SimpleNamespace(**i)
            cpu_id = db_handler.get_cpu_id(i.id)
            if cpu_id == None:
                cpu_id = db_handler.create_cpu(
                    i.id,
                    i.name,
                    i.description,
                    i.brand["name"] if i.brand != None else None,
                    i.rating["average"] if i.brand != None else None,
                    i.rating["count"] if i.brand != None else None,
                    (
                        ("https://www.pricerunner.dk" + i.image["path"])
                        if i.image != None
                        else None
                    ),
                    float(i.lowestPrice["amount"]) if i.lowestPrice != None else None,
                )
            else:
                db_handler.update_cpu(
                    cpu_id,
                    i.id,
                    i.name,
                    i.description,
                    i.brand["name"] if i.brand != None else None,
                    i.rating["average"] if i.brand != None else None,
                    i.rating["count"] if i.brand != None else None,
                    (
                        ("https://www.pricerunner.dk" + i.image["path"])
                        if i.image != None
                        else None
                    ),
                    float(i.lowestPrice["amount"]) if i.lowestPrice != None else None,
                )
            db_handler.create_price(
                float(i.lowestPrice["amount"]) if i.lowestPrice != None else None,
                f"https://www.pricerunner.dk{i.cheapestOffer["url"]}",
                cpu_id
            )

            if DEBUG:
                print(
                    f"""
                    {i.id},
                    {i.name},
                    {i.description},
                    {i.brand["name"] if i.brand != None else None},
                    {i.rating["average"] if i.brand != None else None},
                    {i.rating["count"] if i.brand != None else None},
                    {("https://www.pricerunner.dk" + i.image["path"]) if i.image != None else None},
                    {i.lowestPrice["amount"] if i.lowestPrice != None else None},
                    """
                )

        response = SimpleNamespace(**requests.get(uri + f"&offset={100*cnt}").json())
        cnt += 1
        pages -= 1
