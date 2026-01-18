# Edge Case & Negative Tests

## TC-EC-01: Empty Input for IDs
Steps:
1. Press Enter without input

Expected Result:
- Validation error
- Prompt again

---

## TC-EC-02: Case Insensitive IDs
Steps:
1. Enter lowercase book/member IDs

Expected Result:
- System handles IDs correctly

---

## TC-EC-03: Multiple Back Operations
Steps:
1. Navigate deep into menus
2. Press Back repeatedly

Expected Result:
- No crash
- Correct navigation

---

## TC-EC-04: Repeated Issue & Return
Steps:
1. Issue and return same book multiple times

Expected Result:
- System state remains consistent

---

## TC-EC-05: Maximum Limits
Steps:
1. Add max books, members, issues

Expected Result:
- No overflow
- Proper blocking messages
