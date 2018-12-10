
var all_questions = [{
    question_string: "La causa más común de conflictos en proyectos es:",
    choices: {
        correct: "Cronograma",
        wrong: ["Opiniones técnicas", "Discusiones personales", "Prioridades del proyecto"]
    }
},
    {
        question_string: "¿Cuál es un proceso del área de conocimiento de la administración del alcance? ",
    choices: {
        correct: "Identificar alcance",
        wrong: ["Clarificar alcance", "Controlar alcance", "Cerrar alcance"]
    }
 },
    {
        question_string: "¿Cuál de los procesos identifica el administrador del proyecto?",
    choices: {
        correct: "Desarrollar el acta constitutiva",
        wrong: ["Desarrollar el plan del proyecto", "Definir el alcance", "Seleccionar el proceso del proyecto"]
    }
 },
    {
        question_string: "¿Cuál de los siguientes procesos produce una salida de la EDT?",
    choices: {
        correct: "Crear la EDT",
        wrong: ["Definir actividades", "Inicio del proyecto", "Plan del alcance"]
    }
 },
    {
        question_string: "¿Cuál de las siguientes teorías fue sugerida por Deming?",
    choices: {
        correct: "Planear - Hacer - Verificar - Actuar para mejorar la calidad",
        wrong: ["Aplicar pequeñas mejoras continuas para reducir costo y asegurar consistencia", "Análisis marginal", "Teoría de la expectativa - las personas esperan ser remuneradas por su esfuerzo"]
    }
    },
    {
        question_string: "Usted es el administrador de proyecto de una empresa de manufactura de autos. Como parte del control de calidad usted decide verificar sólo el 5% de los autos generados por el verificador ambiental. ¿Cuál técnica usaría?",
    choices: {
        correct: "Muestreo estadístico",
        wrong: ["Diagrama de pareto", "Cuadros de control", "Selección de muestra"]
    }
    },
    {
        question_string: "Ejecutar el proceso de Aseguramiento de la calidad es parte de la siguiente fase:",
        choices: {
            correct: "Ejecución",
            wrong: ["Planeación", "Control", "Cierre"]
        }
    },
    {
        question_string: "¿Cuál de las siguientes no es una herramienta de ejecutar el proceso control de calidad? ",
        choices: {
            correct: "Evaluación comparativa",
            wrong: ["Diagramas de flujo", "Histograma", "Inspección"]
        }
    },
    {
        question_string: "¿Cuál de las siguientes salidas pertenece al proceso de Identificar el riesgo?",
        choices: {
            correct: "Registro de riesgos",
            wrong: ["Lecciones aprendidas", "Listas de verificación", "Análisis SWOT"]
        }
    }, 
    {
        question_string: "¿En cuál del proceso del área de conocimiento de administración del riesgo son valores númericos asignados a las probabilidades e impacto de los riesgos?",
        choices: {
            correct: "Ejecutar el análisis cuantitativo de los riesgos",
            wrong: ["Ejecutar el análisis cualitativo de los riesgos", "Ejecutar análisis númerico de los riesgos", "Plan de respuesta al riesgo"]
        }
    },
    {
        question_string: "¿Cuál de las siguientes sentencias es verdadera acerca de los riesgos?",
        choices: {
            correct: "La identificación de riesgos sucede durante todo el proyecto",
            wrong: ["Si un riesgo es identificado en un Plan de respuesta al riesgo, entonces significa que el riesgo ya ha ocurrido.", "Una vez que un riesgo ha ocurrido, usted consulta en Plan de administración de riesgos para determinar qué acción fue tomada.", "Un riesgo que no fue planeado pero sucedió, es llamado por un disparador."]
        }
    },
    {
        question_string: "Si usted está administrando el proyecto de planeación de la fiesta de empleados de la compañía. Existe el riesgo de que los empleados podrían no llegar a la fiesta. Usted decide no tomar ninguna acción debido a que esta posibilidad es baja. ¿Cuál estrategia de respuesta al riesgo usted siguió?",
    choices: {
        correct: "Aceptación",
        wrong: ["Prevención", "Mitigación", "Transferencia"]
    }
}];

var Quiz = function (quiz_name) {
   
    this.quiz_name = quiz_name;

    
    this.questions = [];
}


Quiz.prototype.add_question = function (question) {
   
    var index_to_add_question = Math.floor(Math.random() * this.questions.length);
    this.questions.splice(index_to_add_question, 0, question);
}


Quiz.prototype.render = function (container) {
    
    var self = this;

   
    $('#quiz-results').hide();

   
    $('#quiz-name').text(this.quiz_name);

    var question_container = $('<div>').attr('id', 'question').insertAfter('#quiz-name');

   
    function change_question() {
        self.questions[current_question_index].render(question_container);
        $('#prev-question-button').prop('disabled', current_question_index === 0);
        $('#next-question-button').prop('disabled', current_question_index === self.questions.length - 1);


        
        var all_questions_answered = true;
        for (var i = 0; i < self.questions.length; i++) {
            if (self.questions[i].user_choice_index === null) {
                all_questions_answered = false;
                break;
            }
        }
        $('#submit-button').prop('disabled', !all_questions_answered);
    }

    
    var current_question_index = 0;
    change_question();

    
    $('#prev-question-button').click(function () {
        if (current_question_index > 0) {
            current_question_index--;
            change_question();
        }
    });

   
    $('#next-question-button').click(function () {
        if (current_question_index < self.questions.length - 1) {
            current_question_index++;
            change_question();
        }
    });

  
    $('#submit-button').click(function () {
       
        var score = 0;
        for (var i = 0; i < self.questions.length; i++) {
            if (self.questions[i].user_choice_index === self.questions[i].correct_choice_index) {
                score++;
            }

            $('#quiz-retry-button').click(function (reset) {
                quiz.render(quiz_container);
            });

        }



       
        var percentage = score / self.questions.length;
        console.log(percentage);
        var message;
        if (percentage === 1) {
            message = '¡Muy Bien!'
        } else if (percentage >= .75) {
            message = '¡Te falto poco, sigue así!'
        } else if (percentage >= .5) {
            message = 'Mas suerte la proxima'
        } else {
            message = 'Tal vez deberías estudiar un poco más ;)'
        }
        $('#quiz-results-message').text(message);
        $('#quiz-results-score').html('You got <b>' + score + '/' + self.questions.length + '</b> questions correct.');
        $('#quiz-results').slideDown();
        $('#submit-button').slideUp();
        $('#next-question-button').slideUp();
        $('#prev-question-button').slideUp();
        $('#quiz-retry-button').sideDown();

    });

   
    question_container.bind('user-select-change', function () {
        var all_questions_answered = true;
        for (var i = 0; i < self.questions.length; i++) {
            if (self.questions[i].user_choice_index === null) {
                all_questions_answered = false;
                break;
            }
        }
        $('#submit-button').prop('disabled', !all_questions_answered);
    });
}

var Question = function (question_string, correct_choice, wrong_choices) {
    this.question_string = question_string;
    this.choices = [];
    this.user_choice_index = null; 

    this.correct_choice_index = Math.floor(Math.random(0, wrong_choices.length + 1));

   
    var number_of_choices = wrong_choices.length + 1;
    for (var i = 0; i < number_of_choices; i++) {
        if (i === this.correct_choice_index) {
            this.choices[i] = correct_choice;
        } else {
            
            var wrong_choice_index = Math.floor(Math.random(0, wrong_choices.length));
            this.choices[i] = wrong_choices[wrong_choice_index];

            
            wrong_choices.splice(wrong_choice_index, 1);
        }
    }
}

Question.prototype.render = function (container) {
    var self = this;

    var question_string_h2;
    if (container.children('h2').length === 0) {
        question_string_h2 = $('<h2>').appendTo(container);
    } else {
        question_string_h2 = container.children('h2').first();
    }
    question_string_h2.text(this.question_string);

    if (container.children('input[type=radio]').length > 0) {
        container.children('input[type=radio]').each(function () {
            var radio_button_id = $(this).attr('id');
            $(this).remove();
            container.children('label[for=' + radio_button_id + ']').remove();
        });
    }
    for (var i = 0; i < this.choices.length; i++) {
        
        var choice_radio_button = $('<input>')
            .attr('id', 'choices-' + i)
            .attr('type', 'radio')
            .attr('name', 'choices')
            .attr('value', 'choices-' + i)
            .attr('checked', i === this.user_choice_index)
            .appendTo(container);

        
        var choice_label = $('<label>')
            .text(this.choices[i])
            .attr('for', 'choices-' + i)
            .appendTo(container);
    }

   
    $('input[name=choices]').change(function (index) {
        var selected_radio_button_value = $('input[name=choices]:checked').val();

       
        self.user_choice_index = parseInt(selected_radio_button_value.substr(selected_radio_button_value.length - 1, 1));

        
        container.trigger('user-select-change');
    });
}
$(document).ready(function () {
    var quiz = new Quiz('PMP Quiz');

    for (var i = 0; i < all_questions.length; i++) {
        var question = new Question(all_questions[i].question_string, all_questions[i].choices.correct, all_questions[i].choices.wrong);

        quiz.add_question(question);
    }

    var quiz_container = $('#quiz');
    quiz.render(quiz_container);
});