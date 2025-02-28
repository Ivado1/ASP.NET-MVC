WITH subquery AS (
    SELECT
        RegionName,
		ProductName,
        SUM(ProductCount) AS Quantity,
        COUNT(DISTINCT PersonId) AS Customers,
        SUM(ProductCount * Price) AS Summa
    FROM
        OrderItem
    JOIN
        Person ON OrderItem.PersonId = Person.Id
    JOIN
        Region ON RegionId = Region.Id
    JOIN
        Price ON OrderItem.PriceId = Price.Id
    JOIN
        Product ON Price.ProductId = Product.Id
    GROUP BY
        Region.RegionName, Product.ProductName
),

ranked_products AS (
  SELECT
    RegionName,ProductName,Quantity,Customers,Summa,
    ROW_NUMBER() OVER (PARTITION BY RegionName ORDER BY Summa DESC) AS RowNum
  FROM
    subquery
  WHERE
    Quantity > 2000 AND
    Summa > 5000000 AND
    Customers > 400
)

SELECT
    RegionName,ProductName,Quantity,Customers,Summa
FROM
    ranked_products
WHERE
    RowNum = 1
ORDER BY
    RegionName
LIMIT 10;