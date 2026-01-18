# Book Management – Test Cases

## TC-BM-01: Add Book Successfully
Precondition:
- BookManager has available capacity

Steps:
1. Navigate to Book Management
2. Select Add Book
3. Enter valid Title, Author, Category

Expected Result:
- Book added successfully
- BookID generated (B001, B002, ...)
- Status set to Available

---

## TC-BM-02: Add Book When Capacity Full
Precondition:
- BookManager capacity is full

Steps:
1. Navigate to Book Management
2. Attempt Add Book

Expected Result:
- Message: "Library Full"
- Add Book option hidden/disabled

---

## TC-BM-03: View All Books
Steps:
1. Navigate to Book Management
2. Select View All Books

Expected Result:
- Books displayed in tabular format
- Status shown correctly (Available / Issued)

---

## TC-BM-04: View Book by Valid ID
Steps:
1. Select View Book by ID
2. Enter valid BookID

Expected Result:
- Correct book details displayed

---

## TC-BM-05: View Book by Invalid ID
Steps:
1. Enter non-existing BookID

Expected Result:
- Error message indicating book not found

---

## TC-BM-06: Delete Book Successfully
Precondition:
- Book exists and is not issued

Steps:
1. Select Delete Book
2. Enter BookID

Expected Result:
- Book removed from system

---

## TC-BM-07: Delete Issued Book
Precondition:
- Book is currently issued

Steps:
1. Attempt to delete the book

Expected Result:
- Operation fails
- Book remains in system
