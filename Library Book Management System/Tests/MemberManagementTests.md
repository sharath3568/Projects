# Member Management – Test Cases

## TC-MM-01: Add Member Successfully
Precondition:
- MemberManager has capacity

Steps:
1. Navigate to Member Management
2. Select Add Member
3. Enter valid name and max allowed books

Expected Result:
- Member created
- MemberID generated (M001, M002, ...)

---

## TC-MM-02: Add Member When Capacity Full
Precondition:
- MemberManager capacity is full

Steps:
1. Attempt Add Member

Expected Result:
- Message indicating capacity reached
- Add option disabled

---

## TC-MM-03: View All Members
Steps:
1. Select View All Members

Expected Result:
- Member list displayed with issued count

---

## TC-MM-04: View Member by ID
Steps:
1. Enter valid MemberID

Expected Result:
- Member details displayed

---

## TC-MM-05: Delete Member With No Issued Books
Precondition:
- Member has 0 issued books

Expected Result:
- Member deleted successfully

---

## TC-MM-06: Delete Member With Issued Books
Precondition:
- Member has active issued books

Expected Result:
- Delete operation fails
- Proper error message shown
