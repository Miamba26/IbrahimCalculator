function bindCalculators() {
    const btn_Calcs = document.querySelectorAll("[name='btn_Calc']");

    for (let i = 0; i < btn_Calcs.length; i++) {
        const btn_Calc = btn_Calcs[i];
        const parentBtn_Calc = btn_Calc.parentElement;

        const txtValue1 = parentBtn_Calc.querySelector("[name='txtValue1_Calc']");
        const ddlOperator = parentBtn_Calc.querySelector("[name='ddlOperator_Calc']");
        const txtValue2 = parentBtn_Calc.querySelector("[name='txtValue2_Calc']");
        const divResult = parentBtn_Calc.querySelector("[name='divResult_Calc']");

        btn_Calc.addEventListener("click", function () {
            doCalculation(txtValue1.value, ddlOperator.value, txtValue2.value, divResult);
        });
    }
}

function doCalculation(value1, operator, value2, divResult) {
    // validation
    if (value1 === "" || value2 === "") {
        divResult.innerHTML = "Please enter a number.";
        return;
    }

    var result = calculate(Number(value1), operator, Number(value2));
    divResult.innerHTML = result;
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