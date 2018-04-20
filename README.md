# Gummi Bear Kingdom

##### A website and blog for the Gummi Bear Kingdom company. 4/20/2018

## By Kayla Ondracek

# Description
This website currently allows users to add new products to Gummi Bear Kingdom's inventory. Users may create, edit, and delete products, as well as delete all products. In the future, they will be able to add blog posts as well.

A note about dummy data - this app will generate 3 dummy data objects and add them to the database when the user arrives to the home page and has no objects in their database. If the user navigates to the home page after having deleted all their objects, these 3 objects will be added back to the database.

## Specs
* Program should have a landing page from where user can go see products
	* Input: User arrives on the home page
	* Output: Links to other areas of the site and a summary of the business
* Program should list all available products
	* Input: User arrives on products page
	* Output: A list of products
* An admin should be able to add new products
	* Input: Name, Description, and Cost information
	* Output: A new product object in the database
* A user should be able to click on each product and see details
	* Input: User clicks a product/link to details page.
	* Output: Details for that product via product id
* An admin should be able to edit a product's information
	* Input: User clicks "edit" on a product
	* Output: User is taken to a form where they can edit the Name, Description, and Cost of the product
* An admin should be able to remove individual products
	* Input: Admin clicks delete on an item
	* Output: User is first presented with a confirmation page, and then the option to follow through with deletion
* An admin should be able to remove all products
	* Input: Admin clicks "delete all products"
	* Output: User is first presented with a confirmation page, and then the option to follow through with deleting all products.
* User should be able to create a blog post with title, author, and textbody
	* Input: Title, Author, and textbody
	* Output: A new blog post should be created with a DateTime stamp.
* Program should list all blog posts
	* Input: User arrives on blog post page
	* Output: A list of posts
* Admin should be able to delete a blog post
	* Input: Admin clicks delete on a post
	* Output: User is first presented with a confirmation page, and then the option to delete post
* An admin should be able to edit a blog post
	* Input: User clicks "edit" on a post
	* Output: User is taken to a form where they can edit the Title, Author, and TextBody of the post

## Future Features
* User will be able to post a review for a product
* User will be able to rate products
* Landing page will show top 3 products


## Technologies Used
* Bootstrap
* C#/ASP.NET
* Entity Framework
* MySql/MAMP

## Setup/Installation Instructions
  * Clone the GitHub repository:
  ```
  $ git clone https://github.com/grepcats/gummi-bear-kingdom
  ```

  * Install the .NET Framework and MAMP

    .NET Core 1.1 SDK (Software Development Kit)
    .NET runtime.
    MAMP

    See https://www.learnhowtoprogram.com/c/getting-started-with-c/installing-c for instructions and links.

* Start the Apache and MySql Servers in MAMP. Make sure you use the default port settings for Apache and MySql (8888 and 8889, respectively)

* `cd GummiBearKingdom/GummiBear`

*  Setup the database

  ```
  $ dotnet ef database update
  ```
*  Restore dependencies and run the program
  ```
  $ dotnet restore
  $ dotnet run
  ```

### License

*MIT License*

Copyright (c) 2018 **_Kayla Ondracek_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

## Additional Notes
Color scheme generated with https://coolors.co/
Scheme: https://coolors.co/1c3144-f3de8a-eb9486-a5a6c9-f9f8f8
Lorem Ipsum on Home page courtesy of http://www.bobrosslipsum.com/
