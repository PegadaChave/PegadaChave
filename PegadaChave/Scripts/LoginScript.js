function showForm(formId) {
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        if (form.id === formId) {
            form.classList.add('active');
        } else {
            form.classList.remove('active');
        }
    });

    const links = document.querySelectorAll('.options a');
    links.forEach(link => {
        if (link.getAttribute('onclick') === `showForm('${formId}')`) {
            link.classList.add('active');
        } else {
            link.classList.remove('active');
        }
    });
}