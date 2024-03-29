USE [OrderManagement]
GO
/****** Object:  StoredProcedure [dbo].[AddNewProduct]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[AddNewProduct]                      
(                      
 @product_id VARCHAR(60),                      
 @product_name VARCHAR(Max),                      
 @product_description VARCHAR(Max),                      
 @weight float,                      
 @height float,                      
 @image_url VARCHAR(Max),                      
 @SKU int,                      
 @barcode varchar(50),                      
 @available_qty int,                  
 @price float 
     )                  
AS                      
BEGIN                          
   Insert Into ProductDetails (product_id, product_name, product_description, weight,height, image, SKU, bar_code, available_qty, price)
   Values (@product_id, @product_name, @product_description, @weight,@height, @image_url, @SKU,@barcode, @available_qty, @price)
END
GO
/****** Object:  StoredProcedure [dbo].[AddNewUser]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddNewUser]                      
(                      
 @user_id VARCHAR(60),                      
 @first_name VARCHAR(50),                      
 @last_name VARCHAR(50),                      
 @email_address VARCHAR(Max),                      
 @alternate_email_address VARCHAR(Max) = null,                      
 @Phone nchar(15),                      
 @Role nchar(10),                      
 @IsDeactive nchar(2),                      
 @Password varchar(max),                  
 @CreatedDate DateTime 
     )                  
AS                      
BEGIN                  
   Declare @Last_activity_on  datetime, @IsAdmin nvarchar(2)
   BEGIN  
   Set @Last_activity_on = GETDATE()
   END
   IF(@Role = 'admin')                        
   BEGIN                         
   SET @IsAdmin = '1'                            
   END                        
   ELSE                        
   BEGIN                         
   SET @IsAdmin = '0'                          
 END        
   Insert Into UserDetails (User_Id, First_Name, Last_Name, Email_Address, Password, Alternate_Email_Address, Phone_Number, Created_Date, IsAdmin, IsDeactive, Last_Activity_On)
   Values (@user_id, @first_name, @last_name, @email_address,@Password, @alternate_email_address, @Phone,@CreatedDate, @Role, @IsDeactive, @Last_activity_on)
END
GO
/****** Object:  StoredProcedure [dbo].[AddProductToCart]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[AddProductToCart]                      
(                      
 @user_id VarChar(50),                      
 @product_id VarChar(50),                      
 @quantity int,                      
 @amount float,                      
 @product_added_on datetime
 )                  
AS      
Declare @total_amount float, @isOrdered nchar(10), @ProductExistInCart int
BEGIN
SET @total_amount = @quantity*@amount
SET @isOrdered = '0'
END                
BEGIN
Select @ProductExistInCart = Count(*) from CartDetails where user_id = @user_id and product_id = @product_id and is_ordered = '0'
if(@ProductExistInCart = 0)
BEGIN
   Insert Into CartDetails (user_id, product_id, quantity, amount,total_amount, is_ordered, item_added_on)
   Values (@user_id, @product_id, @quantity, @amount,@total_amount,@isOrdered,@product_added_on )
END
else
BEGIN
	Update CartDetails set quantity = quantity + @quantity, total_amount = amount * (quantity) where product_id = @product_id and user_id = @user_id
END
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductById]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[DeleteProductById]                      
(                      
 @product_id VARCHAR(60)                     
 
)                  
AS                      
BEGIN                          
   Delete from ProductDetails where product_id = @product_id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteProductFromCart]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[DeleteProductFromCart]  
(                      
 @user_id VarChar(50),                      
 @product_id VarChar(50)    
 )                  
AS      
       
BEGIN
Delete From CartDetails where user_id = @user_id and product_id = @product_id
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]        
(        
 @Id varchar(Max)  
)        
AS        
BEGIN        
 DECLARE @UserRole varchar(5)     
 BEGIN  
 SELECT @UserRole = IsAdmin FROM [UserDetails] WHERE user_id = @Id   
 END  
  --In future if any role add related to admin--  
  DELETE from UserDetails where User_Id = @Id
    
 -- also delete other details related to user--      
END 

GO
/****** Object:  StoredProcedure [dbo].[GetAllProductById]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllProductById]   
(
@ProductID Varchar(50)
)    
AS                      
BEGIN                          
   Select * from ProductDetails where product_id like '%@ProductId%'
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProducts]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllProducts]       
AS                      
BEGIN                          
   Select * from ProductDetails
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllProductsByName]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetAllProductsByName]   
(
@ProductName Varchar(50)
)    
AS                      
BEGIN                          
   Select * from ProductDetails where product_name like '%@ProductName%'
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllUser]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllUser]

AS
BEGIN
	SELECT * FROM UserDetails
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserIdByEmail]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserIdByEmail]
(
	@Email VARCHAR(60)
)
AS
BEGIN
	SELECT user_id FROM UserDetails
	WHERE Email_Address = @Email
END
GO
/****** Object:  StoredProcedure [dbo].[OrderPlace]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[OrderPlace]  
(       
@order_id varchar(50),
 @user_id varchar(50),                      
 @shipping_address VarChar(Max) ,
 @pincode int,
 @phone_number varchar(15),
 @order_status varchar(20),
 @payment_type varchar(50),
 @Is_payment_completed varchar(5),
 @date_created datetime

 )                  
AS      
DECLARE @total_amount float = 0.00, @order_number int = @user_id % 10000
BEGIN
Select @total_amount += (product.amount*cart.quantity) from CartDetail cart right join productDeatil product on cart.poduct_id = product.product_id where cart.user_id = @user_id and cart.is_ordered = 0 

Insert Into OrderDetails (order_id,
	user_id,order_status,shipping_address,phone_number,payment_type,Is_payment_completed,PinCode,date_created,total_amount,order_num) 
	Values (@user_id ,@order_status,@shipping_address,@phone_number,@payment_type,@Is_payment_completed,@pincode,@date_created, @total_amount,@order_number )

	Update CartDetails set [is_ordered] = 1 where user_id = @user_id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateProduct]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[UpdateProduct]                      
(                      
 @product_id VARCHAR(60),                      
 @product_name VARCHAR(Max),                      
 @product_description VARCHAR(Max),                      
 @weight float,                      
 @height float,                      
 @image_url VARCHAR(Max),                      
 @SKU int,                      
 @barcode varchar(50),                      
 @available_qty int,                  
 @price float 
     )                  
AS                      
BEGIN                          
   Update ProductDetails
   Set product_name = @product_name, product_description = @product_description,
       weight = @weight,height = @height, image = @image_url, SKU = @SKU, bar_code = @barcode, available_qty = @available_qty, price = @price
where product_id = @product_id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserById]    Script Date: 4/20/2020 3:31:24 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[UpdateUserById]                      
(                      
 @user_id VARCHAR(60),                      
 @first_name VARCHAR(50),                      
 @last_name VARCHAR(50),                      
 @email_address VARCHAR(Max),                      
 @alternate_email_address VARCHAR(Max) = null,                      
 @Phone nchar(15),                      
 @Role nchar(10),                      
 @IsDeactive nchar(2),                      
 @Password varchar(max)
 )                  
AS                      
BEGIN                  
   Declare @Last_activity_on datetime, @DeactiveOn  datetime, @IsAdmin nvarchar(2)
   BEGIN  
   Set @Last_activity_on = GETDATE()
   END
   IF(@Role = 'admin')                        
   BEGIN                         
   SET @IsAdmin = '1'                            
   END                        
   ELSE                        
   BEGIN                         
   SET @IsAdmin = '0'                          
 END        
   Update UserDetails 
   Set First_Name = @first_name , 
   Last_Name = @last_name,
    Email_Address = @email_address,
	Password = @Password,
	Alternate_Email_Address = @alternate_email_address, 
	Phone_Number = @Phone,
	IsAdmin = @IsAdmin,
	IsDeactive = @IsDeactive,
    Last_Activity_On = @Last_activity_on
	where User_Id = @user_id
END
GO
