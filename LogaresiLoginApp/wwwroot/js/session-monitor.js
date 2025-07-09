(function () {
    // 20 minutos = 20 * 60 * 1000 ms
    const INACTIVITY_LIMIT = 2 * 60 * 1000;
    const WARNING_BEFORE = 45 * 1000;

    let warningTimer, logoutTimer, countdownInterval;

    // Instanciamos el modal de Bootstrap 5
    const modalEl = document.getElementById('sessionWarningModal');
    const sessionModal = new bootstrap.Modal(modalEl, { backdrop: 'static', keyboard: false });
    const countdownEl = document.getElementById('countdown');
    const extendBtn = document.getElementById('extendSessionBtn');

    function resetTimers() {
        clearTimeout(warningTimer);
        clearTimeout(logoutTimer);
        clearInterval(countdownInterval);
        sessionModal.hide();

        // programar warning (INACTIVITY_LIMIT - WARNING_BEFORE)
        warningTimer = setTimeout(showWarningModal, INACTIVITY_LIMIT - WARNING_BEFORE);
        // programar logout en INACTIVITY_LIMIT
        logoutTimer = setTimeout(logoutDueToInactivity, INACTIVITY_LIMIT);
    }

    function showWarningModal() {
        let remaining = Math.floor(WARNING_BEFORE / 1000);
        countdownEl.textContent = remaining;
        sessionModal.show();

        countdownInterval = setInterval(() => {
            remaining--;
            if (remaining <= 0) {
                clearInterval(countdownInterval);
            } else {
                countdownEl.textContent = remaining;
            }
        }, 1000);
    }

    function logoutDueToInactivity() {
        // Mensaje final
        alert('Su sesión ha expirado debido a inactividad. Por favor, inicie sesión nuevamente.');
        window.location.href = '/Account/Logout';
    }

    // Extender sesión
    extendBtn.addEventListener('click', resetTimers);

    // Capturar actividad del usuario
    ['click', 'mousemove', 'keydown', 'scroll', 'touchstart'].forEach(evt =>
        document.addEventListener(evt, resetTimers, true)
    );

    // Iniciar conteo
    resetTimers();
})();
