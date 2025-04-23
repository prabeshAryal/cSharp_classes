// Site JavaScript file for OurNotificationAPP

// Wait for the document to be fully loaded
document.addEventListener('DOMContentLoaded', function () {
    // Initialize tooltips if Bootstrap 5 is being used
    if (typeof bootstrap !== 'undefined' && typeof bootstrap.Tooltip !== 'undefined') {
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'));
        tooltipTriggerList.map(function (tooltipTriggerEl) {
            return new bootstrap.Tooltip(tooltipTriggerEl);
        });
    }

    // Add animation class to notification entries
    const notificationEntries = document.querySelectorAll('.notification-entry');
    notificationEntries.forEach((entry, index) => {
        setTimeout(() => {
            entry.classList.add('show');
        }, 100 * index);
    });
});

// Function to copy code to clipboard (for demonstration purposes)
function copyToClipboard(text) {
    navigator.clipboard.writeText(text).then(
        function () {
            // Show success message
            const tooltip = document.getElementById('copyTooltip');
            if (tooltip) {
                tooltip.innerText = 'Copied!';
                setTimeout(() => {
                    tooltip.innerText = 'Copy to clipboard';
                }, 2000);
            }
        },
        function (err) {
            console.error('Could not copy text: ', err);
        }
    );
}

// Function to toggle notification type selection UI (if implemented)
function toggleNotificationType(type) {
    const emailSection = document.getElementById('emailOptions');
    const smsSection = document.getElementById('smsOptions');

    if (emailSection && smsSection) {
        if (type === 'email') {
            emailSection.classList.remove('d-none');
            smsSection.classList.add('d-none');
        } else if (type === 'sms') {
            emailSection.classList.add('d-none');
            smsSection.classList.remove('d-none');
        }
    }
}

// Function to display notification status with nice animation
function showNotificationStatus(status, message) {
    const statusContainer = document.getElementById('notificationStatus');
    if (!statusContainer) return;

    // Create status element
    const statusElement = document.createElement('div');
    statusElement.className = `alert alert-${status === 'success' ? 'success' : 'danger'} notification-entry`;
    statusElement.innerHTML = message;

    // Add to container
    statusContainer.appendChild(statusElement);

    // Auto remove after delay
    setTimeout(() => {
        statusElement.style.opacity = '0';
        setTimeout(() => {
            statusContainer.removeChild(statusElement);
        }, 300);
    }, 3000);
}