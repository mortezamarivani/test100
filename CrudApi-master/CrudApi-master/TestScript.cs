


---------------------------------------------Edit--------------------------------------- -
Response status code is 200

PASSED

pm.test('Response status code is 200', function () {
    pm.response.to.have.status(200);
});
Response has the required fields

PASSED

pm.test('Response has the required fields', function () {
    const responseData = pm.response.json();
    pm.expect(responseData).to.be.an('object');
    pm.expect(responseData.status).to.exist;
});
Status is a non-empty string

PASSED

pm.test('Status is a non-empty string', function () {
    const responseData = pm.response.json();
    pm.expect(responseData.status).to.be.a('string').and.to.have.lengthOf.at.least(1, 'Value should not be empty');
});
Validate that the status is updated correctly after the PUT request

PASSED

pm.test('Validate that the status is updated correctly after the PUT request', function () {
    const responseData = pm.response.json();
    pm.expect(responseData).to.be.an('object');
    pm.expect(responseData.status).to.exist.and.to.be.a('string');
});
Response time is in an acceptable range

PASSED

pm.test('Response time is in an acceptable range', function () {
    pm.expect(pm.response.responseTime).to.be.below(1000);
});


----------------------------------------Create---------------------------------------------
Response status code is 200

PASSED

pm.test('Response status code is 200', function () {
    pm.response.to.have.status(200);
});
Validate the status field in the response

PASSED

pm.test('Validate the status field in the response', function () {
    const responseData = pm.response.json();
pm.expect(responseData.status).to.exist.and.to.be.a('string');
});
Validate the 'data' object in the response

PASSED

pm.test('Validate the \'data\' object in the response', function () {
    const responseData = pm.response.json();
pm.expect(responseData).to.be.an('object');
pm.expect(responseData.data).to.exist.and.to.be.an('object');
});
Validate response properties

FAILED

pm.test('Validate response properties', function () {
    const responseData = pm.response.json();
pm.expect(responseData).to.be.an('object');
pm.expect(responseData.firstname).to.exist;
pm.expect(responseData.lastname).to.exist;
pm.expect(responseData.phoneNumber).to.exist;
pm.expect(responseData.email).to.exist;
pm.expect(responseData.createDate).to.exist;
pm.expect(responseData.lastUpdateDate).to.exist;
});




----------------------------------------GetCrudById-------------------------------------------- -

Response status code is 200

PASSED

pm.test('Response status code is 200', function () {
    pm.expect(pm.response.code).to.equal(200);
});
Response has the required fields - status and data

PASSED

pm.test('Response has the required fields - status and data', function () {
    const responseData = pm.response.json();
pm.expect(responseData).to.be.an('object');
pm.expect(responseData.status).to.exist;
pm.expect(responseData.data).to.exist;
});
Status is a non - empty string

  PASSED

pm.test('Status is a non-empty string', function () {
    const responseData = pm.response.json();
pm.expect(responseData.status).to.be.a('string').and.to.have.lengthOf.at.least(1, 'Value should not be empty');
});
Data should be null

FAILED

pm.test('Data should be null', function () {
    const responseData = pm.response.json();
pm.expect(responseData.data).to.be.null;
});
Response time is less than 500ms

PASSED

pm.test('Response time is less than 500ms', function () {
    pm.expect(pm.response.responseTime).to.be.below(500);
});



----------------------------------------GetAllCrud-------------------------------------------- -

    Response status code is 200

PASSED

pm.test('Response status code is 200', function () {
    pm.response.to.have.status(200);
});
Validate the status field in the response

PASSED

pm.test('Validate the status field in the response', function () {
    const responseData = pm.response.json();
pm.expect(responseData.status).to.exist.and.to.be.a('string');
});
Verify that the 'data' array is present and contains at least one element

PASSED

pm.test('Verify that the \'data\' array is present and contains at least one element', function () {
    const responseData = pm.response.json();
pm.expect(responseData).to.be.an('object');
pm.expect(responseData.data).to.exist.and.to.be.an('array').that.is.not.empty;
});