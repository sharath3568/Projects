# Issue & Return – Test Cases

## TC-IR-01: Issue Book to Existing Member
Precondition:
- Member exists
- Book is available
- Member has not reached issue limit

Steps:
1. Select Issue Book
2. Enter valid MemberID
3. Enter valid BookID

Expected Result:
- Book issued
- IssueID generated
- Book status set to Issued
- Member issued count incremented

---

## TC-IR-02: Issue Book When Book Already Issued
Precondition:
- Book is already issued

Expected Result:
- Issue operation fails
- Message shown: Book not available

---

## TC-IR-03: Issue Book When Member Limit Reached
Precondition:
- Member has reached MaxAllowedBooks

Expected Result:
- Issue denied
- Clear failure message

---

## TC-IR-04: Issue Book for New Member
Steps:
1. Choose "New Member"
2. Create member
3. Issue book

Expected Result:
- Member created
- Book issued successfully

---

## TC-IR-05: Return Book Successfully
Precondition:
- Book is issued

Steps:
1. Select Return Book
2. Enter MemberID and BookID

Expected Result:
- Book marked available
- Issue marked returned
- Member issued count decremented

---

## TC-IR-06: Return Book With Invalid IssueID
Steps:
1. Enter invalid BookID or MemberID

Expected Result:
- Return fails gracefully
