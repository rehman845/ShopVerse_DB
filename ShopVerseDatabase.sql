--A-22i_1068-A-22i_2385-A-22i-1200

CREATE DATABASE SHOPVERSE

USE SHOPVERSE;

CREATE TABLE USERS (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    User_FName VARCHAR(20),
    User_LName VARCHAR(20),
    User_Mail VARCHAR(50) UNIQUE,
    User_Password VARCHAR(50),
    Discriminator VARCHAR(20) , -- ('Customer', 'Seller', 'Admin', 'Courier')
);



CREATE TABLE CUSTOMERS (
    UserID INT,
	CustID INT IDENTITY(1, 1) PRIMARY KEY,
    Cust_Gender VARCHAR(10), -- (Male, Female)
    Cust_Phone VARCHAR(11) UNIQUE, 
    Cust_DOB DATE,
    Cust_RegDate DATE,
    Cust_LoginTime DATETIME,
	Cust_FreqLogin INT,
    FOREIGN KEY (UserID) REFERENCES USERS(UserID)  ON DELETE CASCADE
);



CREATE TABLE SELLER (
	UserID INT,
    SellerID INT IDENTITY (1, 1) PRIMARY KEY,
    Seller_StoreName VARCHAR(20) UNIQUE,
    Seller_VerStatus BIT, -- Stores either 0 or 1
    Seller_IBAN VARCHAR(34),
    FOREIGN KEY (UserID) REFERENCES USERS(UserID) ON DELETE CASCADE
);

CREATE TABLE ADMIN (
    AdminID INT IDENTITY (1, 1) PRIMARY KEY,
	UserID INT ,
    FOREIGN KEY (UserID) REFERENCES USERS(UserID) ON DELETE CASCADE
);


CREATE TABLE CARDS (
	CardID INT IDENTITY(1, 1) PRIMARY KEY, 
 	CustID INT ,
 	Card_Num VARCHAR(16) UNIQUE  , 
 	Bank_Name VARCHAR(20)  ,
 	CVV INT  ,
 	Expiry_Date DATE  ,
 	FOREIGN KEY (CustID) REFERENCES CUSTOMERS(CustID) ON DELETE CASCADE
 );

 CREATE TABLE ADDRESS (
    AddressID INT IDENTITY(1,1) PRIMARY KEY,
	CustID INT ,
	SellerID INT ,
 	Plot VARCHAR(5)  ,
 	Area VARCHAR(20)  ,
 	City VARCHAR(20)  ,
 	Province VARCHAR(20)  ,
 	Country VARCHAR(20)  ,
 	ZipCode VARCHAR(5)  ,
	FOREIGN KEY (CustID) REFERENCES CUSTOMERS(CustID),
	FOREIGN KEY (SellerID) REFERENCES SELLER(SellerID)
 );


CREATE TABLE CATEGORY (
 	CatID INT IDENTITY(1,1) PRIMARY KEY,
 	Cat_Name VARCHAR(20) UNIQUE  ,
 	Cat_Creation DATETIME
 );



CREATE TABLE PRODUCTS (
 	ProdID INT IDENTITY(1,1) PRIMARY KEY,
 	CatID INT  ,
 	SellerID INT  ,
 	Prod_Name VARCHAR(20)  ,
 	Prod_Description VARCHAR(100)  ,
 	Prod_Price FLOAT  ,
 	Prod_Release DATETIME,
 	FOREIGN KEY (CatID) REFERENCES CATEGORY(CatID) ON DELETE CASCADE, 
 	FOREIGN KEY (SellerID) REFERENCES SELLER(SellerID)  ON DELETE CASCADE
 );
 



CREATE TABLE REVIEW (
 	ReviewID INT IDENTITY(1,1) PRIMARY KEY,
 	ProdID INT  ,
 	CustID INT  ,
 	Rating INT  ,
 	Comment VARCHAR(100)  ,
 	R_Date DATETIME,
 	FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID) ON DELETE CASCADE,
 	FOREIGN KEY (CustID) REFERENCES CUSTOMERS(CustID) ON DELETE NO ACTION
 );

 

CREATE TABLE CART (
 	CartID INT IDENTITY(1,1) PRIMARY KEY,
 	CustID INT  ,
 	ProdID INT  ,
 	Cart_TotalItems FLOAT  ,
 	Cart_TotalValue FLOAT  ,
 	Cart_ProdQuant INT  ,
 	Cart_SessStart DATETIME,
 	FOREIGN KEY (CustID) REFERENCES CUSTOMERS(CustID) ON DELETE NO ACTION,
 	FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID) ON DELETE NO ACTION
 );


CREATE TABLE WISHLIST (
 	WishID INT IDENTITY(1,1) PRIMARY KEY,
 	CustID INT  ,
 	ProdID INT  ,
 	FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID) ON DELETE NO ACTION,
	FOREIGN KEY (CustID) REFERENCES CUSTOMERS(CustID) ON DELETE NO ACTION
 );





CREATE TABLE INVENTORY (
 	Inventory_ID INT IDENTITY(1,1) PRIMARY KEY,
 	ProdID INT  ,
 	SellerID INT  ,
 	Stock INT  ,
 	Last_Update DATETIME,
 	FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID),
 	FOREIGN KEY (SellerID) REFERENCES SELLER(SellerID) 
 );


CREATE TABLE ORDERS (
 	OrderID INT IDENTITY(1,1) PRIMARY KEY,
 	SellerID INT  ,
 	CustID INT  ,
	LogisticsID INT  ,
 	Order_Return BIT,
 	Order_Date DATE,
 	Order_Amount FLOAT  ,
	Tracking_Number VARCHAR(8),
	Shipment_Status VARCHAR(20), -- ('Pending', 'Shipped', 'In Transit', 'Delivered', 'Returned', 'Cancelled')
	Delivery_Date DATE,
	Return_Approve BIT,
	IsNotified BIT DEFAULT 0,
	EstDelivery_Date DATE,
	OrderShipped DATE,
	SellerAccept BIT,
	FOREIGN KEY (LogisticsID) REFERENCES LOGISTICS(ShipperID),
 	FOREIGN KEY (SellerID) REFERENCES SELLER(SellerID) ,
 	FOREIGN KEY (CustID) REFERENCES CUSTOMERS(CustID) 

 	);


CREATE TABLE ORDER_ITEM (
 	OrderItemID INT IDENTITY(1,1) PRIMARY KEY,
 	OrderID INT  ,
	ProdID INT  ,
 	Order_Amount FLOAT  ,
 	Item_Quant VARCHAR(20)  ,
 	FOREIGN KEY (OrderID) REFERENCES ORDERS(OrderID) ON DELETE CASCADE,
 	FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID) ON DELETE CASCADE
 );



 CREATE TABLE PAYMENTS (
 	PaymentID INT IDENTITY(1,1) PRIMARY KEY,
	OrderID INT  ,
 	Payment_Method VARCHAR (20)  , -- ('CashOnDelivery', 'Card')
 	Payed_Amount FLOAT  ,
 	Payment_Time DATETIME,
	FOREIGN KEY (OrderID) REFERENCES ORDERS(OrderID) ON DELETE CASCADE
 );

 


CREATE TABLE LOGISTICS (
	ShipperID INT IDENTITY(1,1) PRIMARY KEY,
	UserID INT,
	Company_Name VARCHAR(20),
	FOREIGN KEY (UserID) REFERENCES USERS(UserID) ON DELETE CASCADE
 );


CREATE TABLE CART_PROD (
    CartID INT,
    ProdID INT,
    Cart_ProdQuant INT,  
    Cart_ProdTotal FLOAT, 
    PRIMARY KEY (CartID, ProdID),
    FOREIGN KEY (CartID) REFERENCES CART(CartID) ON DELETE CASCADE,
    FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID) ON DELETE CASCADE
);

CREATE TABLE WISH_PROD (
    WishID INT,
    ProdID INT,
    PRIMARY KEY (WishID, ProdID),
    FOREIGN KEY (WishID) REFERENCES WISHLIST(WishID) ON DELETE CASCADE,
    FOREIGN KEY (ProdID) REFERENCES PRODUCTS(ProdID) ON DELETE CASCADE
);



 --Report 1
 CREATE PROCEDURE GetTotalSalesAndAvgOrderValue
    @StartDate DATE,
    @EndDate DATE,
    @SellerMail VARCHAR(50)
AS
BEGIN
    SELECT 
        SUM(O.Order_Amount) AS TotalSales,
        SUM(O.Order_Amount) / COUNT(O.OrderID) AS AvgOrderValue
    FROM ORDERS O
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerMail
    AND O.Order_Date BETWEEN @StartDate AND @EndDate;
END


CREATE PROCEDURE GetBestSellingProducts
    @StartDate DATE,
    @EndDate DATE,
    @SellerMail VARCHAR(50)
AS
BEGIN
    SELECT 
        P.Prod_Name AS BestSellingProduct,
        SUM(OI.Item_Quant) AS QuantitySold
    FROM ORDERS O
    JOIN ORDER_ITEM OI ON O.OrderID = OI.OrderID
    JOIN PRODUCTS P ON OI.ProdID = P.ProdID
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerMail
    AND O.Order_Date BETWEEN @StartDate AND @EndDate
    GROUP BY P.Prod_Name
    ORDER BY QuantitySold DESC;
END


CREATE PROCEDURE GetTopCategory
    @StartDate DATE,
    @EndDate DATE,
    @SellerMail VARCHAR(50)
AS
BEGIN
    SELECT 
        C.Cat_Name AS CategoryName,
        SUM(O.Order_Amount) AS CategorySales
    FROM ORDERS O
    JOIN ORDER_ITEM OI ON O.OrderID = OI.OrderID
    JOIN PRODUCTS P ON OI.ProdID = P.ProdID
        JOIN CATEGORY C ON P.CatID = C.CatID
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerMail
    AND O.Order_Date BETWEEN @StartDate AND @EndDate
    GROUP BY C.Cat_Name
    ORDER BY CategorySales DESC;
END



-- Report 2
CREATE PROCEDURE GetMostActiveCustomers
    @SellerEmail VARCHAR(50)
AS
BEGIN
    DECLARE @SellerID INT;

    SELECT @SellerID = S.SellerID
    FROM SELLER S
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerEmail;

    SELECT C.User_FName, C.User_LName, COUNT(O.OrderID) AS OrderCount
    FROM ORDERS O
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS C ON O.CustID = C.UserID
    WHERE S.SellerID = @SellerID
    GROUP BY C.User_FName, C.User_LName
    ORDER BY OrderCount DESC;
END;


CREATE PROCEDURE GetAverageSpendPerCustomer
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT C.User_FName, C.User_LName, AVG(O.Order_Amount) AS AverageSpend
    FROM ORDERS O
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS C ON O.CustID = C.UserID
    WHERE S.Seller_StoreName = (SELECT Seller_StoreName FROM SELLER S2
                                JOIN USERS U2 ON S2.UserID = U2.UserID
                                WHERE U2.User_Mail = @SellerEmail)
    GROUP BY C.User_FName, C.User_LName;
END;


CREATE PROCEDURE GetRepeatPurchaseRate
    @SellerEmail VARCHAR(50)
AS
BEGIN
    DECLARE @TotalCustomers INT;
    DECLARE @RepeatCustomers INT;

    SELECT @TotalCustomers = COUNT(DISTINCT O.CustID)
    FROM ORDERS O
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS U ON O.CustID = U.UserID
    WHERE S.Seller_StoreName = (SELECT Seller_StoreName FROM SELLER S2
                                JOIN USERS U2 ON S2.UserID = U2.UserID
                                WHERE U2.User_Mail = @SellerEmail);

    SELECT @RepeatCustomers = COUNT(DISTINCT O.CustID)
    FROM ORDERS O
    JOIN SELLER S ON O.SellerID = S.SellerID
    JOIN USERS U ON O.CustID = U.UserID
    WHERE S.Seller_StoreName = (SELECT Seller_StoreName FROM SELLER S2
                                JOIN USERS U2 ON S2.UserID = U2.UserID
                                WHERE U2.User_Mail = @SellerEmail)
    GROUP BY O.CustID
    HAVING COUNT(O.OrderID) > 1;

    SELECT (CAST(@RepeatCustomers AS FLOAT) / CAST(@TotalCustomers AS FLOAT)) * 100 AS RepeatPurchaseRate;
END;


--Report 3
CREATE PROCEDURE GetLowStock
    @SellerEmail VARCHAR(50)   
AS
BEGIN
    SELECT P.Prod_Name,
           I.Stock
    FROM PRODUCTS P
    JOIN SELLER S ON P.SellerID = S.SellerID
    JOIN INVENTORY I ON P.ProdID = I.ProdID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerEmail
      AND I.Stock < 100
    ORDER BY I.Stock ASC;
END;

CREATE PROCEDURE GetDeadStock
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT P.Prod_Name
    FROM PRODUCTS P
    JOIN SELLER S ON P.SellerID = S.SellerID
    LEFT JOIN ORDER_ITEM OI ON OI.ProdID = P.ProdID
    LEFT JOIN ORDERS O ON O.OrderID = OI.OrderID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerEmail
      AND (O.Order_Date IS NULL OR DATEDIFF(DAY, O.Order_Date, GETDATE()) > 30)
    ORDER BY P.Prod_Name;
END;

CREATE PROCEDURE GetStockTurnover
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT P.Prod_Name,
           (SUM(OI.Item_Quant) / AVG(I.Stock)) AS StockTurnoverRate
    FROM PRODUCTS P
    JOIN SELLER S ON P.SellerID = S.SellerID
    JOIN INVENTORY I ON P.ProdID = I.ProdID
    LEFT JOIN ORDER_ITEM OI ON OI.ProdID = P.ProdID
    LEFT JOIN ORDERS O ON O.OrderID = OI.OrderID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY P.Prod_Name
    HAVING AVG(I.Stock) > 0
    ORDER BY StockTurnoverRate DESC;
END;

CREATE PROCEDURE GetMostReturnedItems
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT P.Prod_Name,
           SUM(CASE WHEN O.Order_Return = 1 THEN 1 ELSE 0 END) AS TotalReturns
    FROM PRODUCTS P
    JOIN SELLER S ON P.SellerID = S.SellerID
    JOIN ORDERS O ON O.SellerID = S.SellerID
    JOIN USERS U ON S.UserID = U.UserID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY P.Prod_Name
    HAVING SUM(CASE WHEN O.Order_Return = 1 THEN 1 ELSE 0 END) >= 1
    ORDER BY TotalReturns DESC;
END;








--Report 4

CREATE PROCEDURE GetRevenuePerCategory
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT 
        C.Cat_Name AS Category,
        SUM(OI.Order_Amount) AS Revenue
    FROM USERS U
    INNER JOIN SELLER S ON U.UserID = S.UserID
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN CATEGORY C ON P.CatID = C.CatID
    INNER JOIN ORDER_ITEM OI ON P.ProdID = OI.ProdID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY C.Cat_Name
    ORDER BY Revenue DESC;
END;


CREATE PROCEDURE GetCategoryContribution
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT 
        C.Cat_Name AS Category,
        SUM(OI.Order_Amount) AS Revenue,
        CAST((SUM(OI.Order_Amount) * 100.0 / 
            (SELECT SUM(OI2.Order_Amount)
             FROM USERS U2
             INNER JOIN SELLER S2 ON U2.UserID = S2.UserID
             INNER JOIN PRODUCTS P2 ON S2.SellerID = P2.SellerID
             INNER JOIN ORDER_ITEM OI2 ON P2.ProdID = OI2.ProdID
             WHERE U2.User_Mail = @SellerEmail)) AS DECIMAL(10, 2)) AS PercentageContribution
    FROM USERS U
    INNER JOIN SELLER S ON U.UserID = S.UserID
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN CATEGORY C ON P.CatID = C.CatID
    INNER JOIN ORDER_ITEM OI ON P.ProdID = OI.ProdID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY C.Cat_Name
    ORDER BY Revenue DESC;
END;



CREATE PROCEDURE GetTrendingCategories
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT 
        C.Cat_Name AS Category,
        DATEPART(YEAR, O.Order_Date) AS Year,
        SUM(OI.Order_Amount) AS Revenue
    FROM USERS U
    INNER JOIN SELLER S ON U.UserID = S.UserID
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN CATEGORY C ON P.CatID = C.CatID
    INNER JOIN ORDER_ITEM OI ON P.ProdID = OI.ProdID
    INNER JOIN ORDERS O ON OI.OrderID = O.OrderID
    WHERE U.User_Mail = @SellerEmail
      AND DATEPART(YEAR, O.Order_Date) <= 2024
    GROUP BY C.Cat_Name, DATEPART(YEAR, O.Order_Date)
    ORDER BY C.Cat_Name, Year ASC;
END;


--Report 5

CREATE PROCEDURE GetAverageRatingByProduct
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT 
        P.Prod_Name AS Product,
        AVG(R.Rating) AS AvgRating
    FROM USERS U
    INNER JOIN SELLER S ON U.UserID = S.UserID
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN REVIEW R ON P.ProdID = R.ProdID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY P.Prod_Name
    ORDER BY AvgRating DESC;
END;

CREATE PROCEDURE GetProductSentimentAnalysis
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT 
        P.Prod_Name AS Product,
        COUNT(CASE WHEN R.Comment LIKE '%excellent%' THEN 1 END) AS Excellent,
        COUNT(CASE WHEN R.Comment LIKE '%bad%' THEN 1 END) AS Bad,
        COUNT(CASE WHEN R.Comment LIKE '%poor quality%' THEN 1 END) AS PoorQuality
    FROM USERS U
    INNER JOIN SELLER S ON U.UserID = S.UserID
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN REVIEW R ON P.ProdID = R.ProdID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY P.Prod_Name
    ORDER BY Product;
END;

CREATE PROCEDURE GetTopRatedProducts
    @SellerEmail VARCHAR(50)
AS
BEGIN
    SELECT TOP 5
        P.Prod_Name AS Product,
        AVG(R.Rating) AS AvgRating
    FROM USERS U
    INNER JOIN SELLER S ON U.UserID = S.UserID
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN REVIEW R ON P.ProdID = R.ProdID
    WHERE U.User_Mail = @SellerEmail
    GROUP BY P.Prod_Name
    ORDER BY AvgRating DESC;
END;





--Report 6
CREATE PROCEDURE GetTotalSalesBySellerID
    @SellerID INT
AS
BEGIN
    SELECT 
        S.Seller_StoreName AS Seller,
        SUM(O.Order_Amount) AS TotalSales
    FROM ORDERS O
    INNER JOIN SELLER S ON O.SellerID = S.SellerID
    WHERE S.SellerID = @SellerID
    GROUP BY S.Seller_StoreName;
END;





CREATE PROCEDURE GetAvgRatingByProductSellerID
    @SellerID INT
AS
BEGIN
    SELECT 
        P.Prod_Name AS Product,
        AVG(R.Rating) AS AvgRating
    FROM SELLER S
    INNER JOIN PRODUCTS P ON S.SellerID = P.SellerID
    INNER JOIN REVIEW R ON P.ProdID = R.ProdID
    WHERE S.SellerID = @SellerID
    GROUP BY P.Prod_Name
    ORDER BY AvgRating DESC;
END;



CREATE PROCEDURE GetReturnRateSellerID
    @SellerID INT
AS
BEGIN
    SELECT 
        S.Seller_StoreName AS Seller,
        COUNT(CASE WHEN O.Order_Return = 1 THEN 1 END) * 100.0 / COUNT(*) AS ReturnRefundRate
    FROM ORDERS O
    INNER JOIN SELLER S ON O.SellerID = S.SellerID
    WHERE S.SellerID = @SellerID
    GROUP BY S.Seller_StoreName;
END;


--Report 7
CREATE PROCEDURE GetAverageFulfillmentTime
@Mail VARCHAR(20)
AS
BEGIN
    SELECT 
        AVG(DATEDIFF(DAY, O.Order_Date, O.OrderShipped)) AS AverageFulfillmentTimeInDays
    FROM ORDERS O
    WHERE O.Shipment_Status = 'Shipped';
END;


CREATE PROCEDURE GetShippingDelays
@Mail VARCHAR(20)
AS
BEGIN
    SELECT 
        O.OrderID,
        O.Order_Date,
        O.EstDelivery_Date,
        O.Delivery_Date,
        DATEDIFF(DAY, O.EstDelivery_Date, O.Delivery_Date) AS DelayDays
    FROM ORDERS O
    WHERE O.Delivery_Date > O.EstDelivery_Date;
END;


CREATE PROCEDURE GetMostReliableShippingProviders
@Mail VARCHAR(20)
AS
BEGIN
    SELECT 
        L.Company_Name AS ShippingProvider,
        AVG(DATEDIFF(DAY, O.Order_Date, O.Delivery_Date)) AS AvgDeliveryTime
    FROM ORDERS O
    JOIN LOGISTICS L ON O.LogisticsID = L.ShipperID
    GROUP BY L.Company_Name
    ORDER BY AvgDeliveryTime; -- Returning -2 for Leopards because of NULLs in testing data
END;

CREATE PROCEDURE GetOrderCompletionRate
@Mail VARCHAR(20)
AS
BEGIN
    DECLARE @TotalOrders INT;
    DECLARE @CompletedOrders INT;

    SELECT @TotalOrders = COUNT(OrderID)
    FROM ORDERS O;

    SELECT @CompletedOrders = COUNT(OrderID)
    FROM ORDERS O
    WHERE O.Shipment_Status = 'Delivered';

    SELECT (CAST(@CompletedOrders AS FLOAT) / CAST(@TotalOrders AS FLOAT)) * 100 AS OrderCompletionRate; --23Percent
END;



--Report 8

CREATE PROCEDURE GetAbandonedCartCount
    @Days INT
AS
BEGIN
    SELECT 
        COUNT(DISTINCT CartID) AS NumberOfAbandonedCarts
    FROM CART
    WHERE Cart_SessStart < DATEADD(DAY, -@Days, GETDATE()); -- Abandoned carts older than specified days
END;

CREATE PROCEDURE GetAverageAbandonedCartValue
    @Days INT
AS
BEGIN
    SELECT 
        AVG(CartValue) AS AverageAbandonedCartValue
    FROM (
        SELECT 
            C.CartID,
            SUM(P.Prod_Price * C.Cart_ProdQuant) AS CartValue
        FROM CART C
        JOIN PRODUCTS P ON C.ProdID = P.ProdID
        WHERE C.Cart_SessStart < DATEADD(DAY, -@Days, GETDATE()) -- Abandoned carts older than specified days
        GROUP BY C.CartID
    ) AS CartValues;
END;




CREATE PROCEDURE GetFrequentAbandonedProducts
    @Days INT
AS
BEGIN
    SELECT 
        P.Prod_Name,
        COUNT(C.ProdID) AS AbandonmentCount
    FROM CART C
    JOIN PRODUCTS P ON C.ProdID = P.ProdID
    WHERE C.Cart_SessStart < DATEADD(DAY, -@Days, GETDATE()) -- Abandoned carts older than specified days
    GROUP BY P.Prod_Name
    ORDER BY AbandonmentCount DESC;
END;


CREATE PROCEDURE GetCartAbandonmentReasons
    @Days INT
AS
BEGIN
    SELECT 
        Reason,
        COUNT(CartID) AS AffectedCarts
    FROM (
        SELECT 
            CartID,
            CASE 
                WHEN SUM(P.Prod_Price * C.Cart_ProdQuant) > 1000 THEN 'High Total Value'
                WHEN DATEDIFF(DAY, Cart_SessStart, GETDATE()) > @Days THEN 'Long Inactivity'
                ELSE 'Other Reasons'
            END AS Reason
        FROM CART C
        JOIN PRODUCTS P ON C.ProdID = P.ProdID
        WHERE C.Cart_SessStart < DATEADD(DAY, -@Days, GETDATE()) -- Abandoned carts older than specified days
        GROUP BY C.CartID, Cart_SessStart
    ) AS Reasons
    GROUP BY Reason;
END;




--Report 9
CREATE PROCEDURE GetNewUserRegistrations
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    SELECT 
        COUNT(*) AS NewCustomerCount,
        Cust_RegDate AS RegistrationDate
    FROM 
        CUSTOMERS
    WHERE 
        Cust_RegDate BETWEEN @StartDate AND @EndDate
    GROUP BY 
        Cust_RegDate
    ORDER BY 
        RegistrationDate;
END;


CREATE PROCEDURE GetUserEngagementMetrics
AS
BEGIN
    SELECT 
        CustID,
        Cust_FreqLogin AS LoginCount
    FROM 
        CUSTOMERS
    GROUP BY 
        CustID, Cust_FreqLogin
    HAVING 
        Cust_FreqLogin > 0
    ORDER BY 
        Cust_FreqLogin DESC;
END;


CREATE PROCEDURE GetChurnRate
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    DECLARE @TotalCustomers INT, @ChurnedCustomers INT;

    SELECT @TotalCustomers = COUNT(DISTINCT o.CustID) 
    FROM ORDERS o
    WHERE o.Order_Date BETWEEN @StartDate AND @EndDate;

    SELECT @ChurnedCustomers = COUNT(DISTINCT o.CustID)
    FROM ORDERS o
    WHERE o.CustID NOT IN (
        SELECT o1.CustID
        FROM ORDERS o1
        WHERE o1.Order_Date BETWEEN @StartDate AND @EndDate
        GROUP BY o1.CustID
        HAVING COUNT(o1.OrderID) > 1
    )
    AND o.Order_Date BETWEEN @StartDate AND @EndDate;

    SELECT 
        @ChurnedCustomers AS ChurnedCustomers,
        @TotalCustomers AS TotalCustomers,
        CAST(@ChurnedCustomers AS FLOAT) / @TotalCustomers * 100 AS ChurnRatePercentage;

END;



CREATE PROCEDURE GetActiveUserRatio
    @StartDate DATE,
    @EndDate DATE
AS
BEGIN
    DECLARE @TotalUsers INT, @ActiveUsers INT;

    SELECT @TotalUsers = COUNT(*) 
    FROM USERS;

    SELECT @ActiveUsers = COUNT(DISTINCT o.CustID)
    FROM ORDERS o
    WHERE o.Order_Date BETWEEN @StartDate AND @EndDate;

    SELECT 
        @ActiveUsers AS ActiveUsers,
        @TotalUsers AS TotalUsers,
        CAST(@ActiveUsers AS FLOAT) / @TotalUsers * 100 AS ActiveUserRatioPercentage;
END;


--Report 10
CREATE PROCEDURE GetAgeDistribution
@City VARCHAR(20)
AS
BEGIN
    SELECT 
        CASE 
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 0 AND 18 THEN '0-18'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 19 AND 30 THEN '19-30'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 31 AND 40 THEN '31-40'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 41 AND 50 THEN '41-50'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) > 50 THEN '50+'
        END AS AgeGroup,
        COUNT(*) AS NumberOfUsers
    FROM CUSTOMERS
    GROUP BY 
        CASE 
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 0 AND 18 THEN '0-18'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 19 AND 30 THEN '19-30'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 31 AND 40 THEN '31-40'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) BETWEEN 41 AND 50 THEN '41-50'
            WHEN DATEDIFF(YEAR, Cust_DOB, GETDATE()) > 50 THEN '50+'
        END
END

CREATE PROCEDURE GetGenderAnalysis
@City VARCHAR (20)
AS
BEGIN
    SELECT 
        Cust_Gender,
        COUNT(*) AS NumberOfUsers,
        (COUNT(*) * 100.0 / (SELECT COUNT(*) FROM CUSTOMERS)) AS Percentage
    FROM CUSTOMERS
    GROUP BY Cust_Gender
END

CREATE PROCEDURE GetLocationBasedInsights
    @City VARCHAR(20)
AS
BEGIN
    SELECT 
        A.City,
        COUNT(DISTINCT O.OrderID) AS TotalOrders,
        SUM(O.Order_Amount) AS TotalSales,
        COUNT(DISTINCT C.CustID) AS ActiveUsers
    FROM ADDRESS A
    JOIN CUSTOMERS C ON A.CustID = C.CustID
    JOIN ORDERS O ON O.CustID = C.CustID
    WHERE A.City = @City
    GROUP BY A.City
END



CREATE PROCEDURE GetDemographicPrefer
@City VARCHAR(20)
AS
BEGIN
    SELECT 
		@City,
        C.Cust_Gender,
        P.Prod_Name,
        COUNT(*) AS PurchaseCount
    FROM ORDER_ITEM OI
    JOIN ORDERS O ON OI.OrderID = O.OrderID
    JOIN CUSTOMERS C ON O.CustID = C.CustID
    JOIN PRODUCTS P ON OI.ProdID = P.ProdID
    GROUP BY C.Cust_Gender, P.Prod_Name
    ORDER BY PurchaseCount DESC
END





SELECT * FROM log_table

DECLARE @TabName VARCHAR(MAX)
DECLARE @PKCol VARCHAR(MAX)
DECLARE @SQL VARCHAR(MAX)

DECLARE TabTrav CURSOR FOR
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME != 'log_table'

OPEN TabTrav

FETCH NEXT FROM TabTrav INTO @TabName

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @PKCol = (
        SELECT COLUMN_NAME
        FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
        WHERE TABLE_NAME = @TabName
          AND OBJECTPROPERTY(OBJECT_ID(CONSTRAINT_SCHEMA + '.' + CONSTRAINT_NAME), 'IsPrimaryKey') = 1
    )

    IF @PKCol IS NOT NULL
    BEGIN
        SET @SQL = '
        CREATE TRIGGER trg_' + @TabName + '_INSERT
        ON ' + @TabName + '
        AFTER INSERT
        AS
        BEGIN
            SET NOCOUNT ON;
            INSERT INTO log_table (Type, Description, DateCreated)
            SELECT ''INSERT'', ''New row inserted in ' + @TabName + '. Key: '' + CAST(' + @PKCol + ' AS NVARCHAR(MAX)), GETDATE()
            FROM INSERTED;
        END;
        '
        EXEC sp_executesql @SQL

        SET @SQL = '
        CREATE TRIGGER trg_' + @TabName + '_UPDATE
        ON ' + @TabName + '
        AFTER UPDATE
        AS
        BEGIN
            SET NOCOUNT ON;
            INSERT INTO log_table (Type, Description, DateCreated)
            SELECT ''UPDATE'', ''Row updated in ' + @TabName + '. Key: '' + CAST(' + @PKCol + ' AS NVARCHAR(MAX)), GETDATE()
            FROM INSERTED;
        END;
        '
        EXEC sp_executesql @SQL

        SET @SQL = '
        CREATE TRIGGER trg_' + @TabName + '_DELETE
        ON ' + @TabName + '
        AFTER DELETE
        AS
        BEGIN
            SET NOCOUNT ON;
            INSERT INTO log_table (Type, Description, DateCreated)
            SELECT ''DELETE'', ''Row deleted from ' + @TabName + '. Key: '' + CAST(' + @PKCol + ' AS NVARCHAR(MAX)), GETDATE()
            FROM DELETED;
        END;
        '
        EXEC sp_executesql @SQL
    END
    ELSE
    BEGIN
        PRINT 'No primary key found for table: ' + @TabName
    END

    FETCH NEXT FROM TabTrav INTO @TabName
END

CLOSE TabTrav
DEALLOCATE TabTrav

CREATE TABLE log_table (
    LogID INT IDENTITY(1,1) PRIMARY KEY,
    Type VARCHAR(50),        
    Description VARCHAR(MAX),
    DateCreated DATETIME     
);