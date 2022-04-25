function bindCalculators() {
    var btn_Calcs = document.querySelectorAll("[name='btn_Calc']");
    var _loop_1 = function (i) {
        var btn_Calc = btn_Calcs[i];
        var parentBtn_Calc = btn_Calc.parentElement;
        if (parentBtn_Calc === null) {
            return "continue";
        }
        var txtValue1 = parentBtn_Calc.querySelector("[name='txtValue1_Calc']");
        var ddlOperator = parentBtn_Calc.querySelector("[name='ddlOperator_Calc']");
        var txtValue2 = parentBtn_Calc.querySelector("[name='txtValue2_Calc']");
        var divResult = parentBtn_Calc.querySelector("[name='divResult_Calc']");
        if (txtValue1 === null || ddlOperator === null || txtValue2 === null || divResult === null) {
            return "continue";
        }
        btn_Calc.addEventListener("click", function () {
            debugger;
            doCalculation(txtValue1.value, ddlOperator.value, txtValue2.value, divResult);
        });
    };
    for (var i = 0; i < btn_Calcs.length; i++) {
        _loop_1(i);
    }
}
function doCalculation(value1, operator, value2, divResult) {
    // validation
    if (value1 === "" || value2 === "") {
        divResult.innerHTML = "Please enter a number.";
        return;
    }
    var result = calculate(Number(value1), operator, Number(value2));
    divResult.innerHTML = result.toString();
}
function calculate(value1, operator, value2) {
    switch (operator) {
        case "add": return value1 + value2;
        case "subract": return value1 - value2;
        case "multiply": return value1 * value2;
        case "divide":
            if (value2 === 0.00) {
                return "Cannot divide by zero.";
            }
            else {
                return value1 / value2;
            }
            break;
    }
    return "Operator not defined!";
}
